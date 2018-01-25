using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Display_Info : MonoBehaviour {

    public GameObject attractor;
    public TextMesh textMesh;

    private Transform[] tickTransforms;
    private Transform aTransform;
    private GameObject displayee;

	// Use this for initialization
	void Start () {
        tickTransforms = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++) {
            tickTransforms[i] = transform.GetChild(i);
        }
        aTransform = attractor.transform;
	}
	
	// Update is called once per frame
	void Update () {
        displayee = GetClosestToAttactor(tickTransforms);
        textMesh.text = displayee.name;
	}

    GameObject GetClosestToAttactor(Transform[] ticks) {
        Transform bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        foreach (Transform tick in ticks) {
            Vector3 directionToTarget = tick.position - aTransform.position;
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if (dSqrToTarget < closestDistanceSqr) {
                closestDistanceSqr = dSqrToTarget;
                bestTarget = tick;
            }
        }

        return bestTarget.gameObject;
    }
}
