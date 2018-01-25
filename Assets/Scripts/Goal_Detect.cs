using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal_Detect : MonoBehaviour {

    public ParticleSystem confetti;
    public int numEmit = 5000;

	// Use this for initialization
	void Start () {
        confetti = GetComponentInChildren<ParticleSystem>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other) {
        
        if (other.tag == "Finish") {

            confetti.Play();
            //confetti.Emit(numEmit);
            //var em = confetti.emission;
            //em.enabled = true;

            print("SCORE");
        }
        
    }

   
}
