using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draw_Ticks : MonoBehaviour {


    public int numPoints = 10;
    private List<Vector4> evenCirclePointsList;
    
    //public GameObject cylinderGO;
    public float cylinderRadius;
    private Vector2 cylinder2DCenter;

    public GameObject tickPrefab;

    // Use this for initialization
    void Start () {
        evenCirclePointsList = new List<Vector4>();

        //cylinderRadius = GetComponent<CapsuleCollider>().radius;
        cylinder2DCenter = new Vector2(transform.position.x, transform.position.z);

        FindCirclePoints(numPoints, cylinderRadius, cylinder2DCenter);
        //print(numPoints);
        //print(cylinderRadius);
        //print(cylinder2DCenter);
        DrawCirclePoints();

    }
	
	// Update is called once per frame
	void Update () {
		//embiggen the ticks near the top of the cylinder
        //angles available from evenCirclePointsList
	}

    void FindCirclePoints(int points, float radius, Vector2 center) {
        float slice = 2 * Mathf.PI / points;
        for (int i = 0; i < points; i++) {
            float angle = slice * i;
            float newX = (center.x + radius * Mathf.Cos(angle));
            float newY = (center.y + radius * Mathf.Sin(angle));
            Vector4 p = new Vector4(newX, newY, transform.position.y, angle);
            //print(p);
            //print(angle);
            evenCirclePointsList.Add(p);
        }
    }


    void DrawCirclePoints() {
        for (int i = 0; i < evenCirclePointsList.Count; i++) {
            GameObject go = Instantiate<GameObject>(tickPrefab, evenCirclePointsList[i], Quaternion.Euler(0f,0f, Mathf.Rad2Deg * evenCirclePointsList[i].w + 90), transform);
            go.name = "Tick" + i;
            go.layer = 8;
        }
    }
}
