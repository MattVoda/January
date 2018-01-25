using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Size_Ticks : MonoBehaviour {

    public float overlapSphereRadius = 1;
    private Collider[] hitColliders;
    private int mask;
    private int tickLayer = 8;
    private List<GameObject> orderedList;


    void Start () {
        hitColliders = new Collider[transform.parent.GetComponentInChildren<Draw_Ticks>().numPoints];
        orderedList = new List<GameObject>();
        mask = 1 << tickLayer;

        InvokeRepeating("CheckOverlap", 0.3f, 0.1f);
    }
	
	void Update () {
        
    }

    void CheckOverlap() {
        hitColliders = Physics.OverlapSphere(transform.position, overlapSphereRadius, mask);

        int i = 0;
        Vector3 currentPosition = transform.position;
        while (i < hitColliders.Length) {
            Vector3 directionToTarget = hitColliders[i].transform.position - currentPosition;
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            
            hitColliders[i].SendMessage("Grow", dSqrToTarget);
            i++;
        }
    }
}
