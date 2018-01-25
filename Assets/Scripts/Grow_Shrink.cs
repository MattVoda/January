using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grow_Shrink : MonoBehaviour {

    private Vector3 startScale;
    private Vector3 startPos;
    public Vector3 endScale;
    public float clampYScale = 2;
    private float verticalBumper = 1.01f;

    private int counter = 0;
    private bool shrunk = true;

    private void Awake() {
        startScale = transform.localScale;
        startPos = transform.position;
    }

    // Use this for initialization
    void Start () {
        if (endScale == Vector3.zero) {
            endScale = new Vector3(0.05f, 1f, 0.2f);
        }
	}
	
	// Update is called once per frame
	void Update () {
		if (counter > 50 && !shrunk) {
            Shrink();
        }
	}

    private void FixedUpdate() {
        counter++;
    }

    void Grow(float sqrDistance) {
        counter = 0;

        float multiplier = 1 - sqrDistance;
        float yScale = endScale.y * multiplier;
        float yScaleClamped = Mathf.Clamp(yScale, startScale.y, endScale.y);
        float yVert = Mathf.Clamp(transform.position.y * verticalBumper, startPos.y, startPos.y * 1.2f);


        iTween.ScaleUpdate(gameObject, iTween.Hash(
            "y", yScaleClamped,
            "time", 0.05
            ));
        iTween.MoveUpdate(gameObject, iTween.Hash(
            "y", startScale.y + (yScale * 0.7)
            ));

        shrunk = false;
    }

    void Shrink() {
        iTween.ScaleTo(gameObject, startScale, 0.1f);
        shrunk = true;
    }
}
