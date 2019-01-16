using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// This script is attached to the dirt hole in Wangari's scene
// This script is keeping track of a collision of a water droplet with the hole
// If there is a collision...
// Grow the tree
// And set the state machine to 2


public class HoleController : MonoBehaviour {

    public GameObject seed_final;
    public GameObject tree_final;

    public Animator animator; 


    private int holeState_final;
    private dropSeed_final seedScript_final;

	void Start () {
        seedScript_final = seed_final.GetComponent<dropSeed_final>();
        animator = tree_final.GetComponent<Animator>();

    }

    void Update () {
        holeState_final = seedScript_final.state_final;
    }


    private void OnTriggerEnter(Collider other)
    {
      
        if (other.tag == "waterDrop")
        {
            Debug.Log("water has collided with hole");
            tree_final.SetActive(true);
            holeState_final = 2;
            Debug.Log("tree has been instantiated and rendered obj finalstate is " + holeState_final);
        }
    }
}
