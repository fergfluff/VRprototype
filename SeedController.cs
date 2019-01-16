using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


// This script is attached to the seed game object 
// This script is using the UnityEngine.UI class
// This script is the start of our state machine, see below.
// This script eventually would handle displaying instructional text to players when they get close enough to game objects
// This script also handles when the raycast of the seed hits the dirt hole's game object's collider...
// The seed is deparented from the player's hand
// The seed's gravity is turned on, its X and Z position and rotation is frozen, and it's given a mass of 3




//STATE CHANGES
//if state = 0
//Let player 1 drop seed in hole, state == 1 (state++)
//if state = 1
//let player 2 pour water, state == 2 (state++)
//if state = 2
//let tree grow, state == 3 (state++)


public class dropSeed_final : MonoBehaviour {


    public Rigidbody seedRigidBody_final;
    public GameObject tree_final;
    public int state_final = 0;

    //public Text PlantSeedText;
    public GameObject handCollider;
    public Transform handColliderPosition;
    public float distanceToSeed;

    //public GameObject WangariAudioPlayer;
    //AudioSource WangariAudio;


    private void Start()
    {
        seedRigidBody_final = GetComponent<Rigidbody>();

        handCollider = GameObject.FindWithTag("hand");
        handColliderPosition = handCollider.GetComponent<Transform>();
        //PlantSeedText = PlantSeedText.GetComponent<Text>();

        //WangariAudio = WangariAudio.GetComponent<AudioSource>();


    }


    void Update () {
        RaycastHit hit;
        Ray rayDirection = new Ray(transform.position, Vector3.down);

        Debug.DrawRay(transform.position, Vector3.down);

        //PlantSeedText.enabled = false;
        //PlantSeedText.gameObject.SetActive(false);

        //WangariAudio.Play();

        if (state_final == 0) {

            Debug.Log("did it get past state change 0?");

            //if the player is close enough to the seed
            //show the text
          // distanceToSeed = Vector3.Distance(handColliderPosition.position, transform.position);
           //if (distanceToSeed < 3f) {
            //    Debug.Log("near seed");
              //  PlantSeedText.gameObject.SetActive(true);
                //PlantSeedText.enabled = true;
           // }
            

            if (Physics.Raycast(rayDirection, out hit))
            {
                if (hit.collider.tag == "hole_final")
                {
                    Debug.Log("deparent seed from hand");
                    transform.parent = null;
                    Debug.Log(transform.parent);

                    seedRigidBody_final.isKinematic = false;
                    seedRigidBody_final.useGravity = true;
                    seedRigidBody_final.constraints = RigidbodyConstraints.FreezePositionX;
                    seedRigidBody_final.constraints = RigidbodyConstraints.FreezePositionZ;
                    seedRigidBody_final.constraints = RigidbodyConstraints.FreezeRotation;
                    seedRigidBody_final.mass = 3f;

                    state_final++;
                   
                }
            }
        }

        Debug.Log("rendered obj state = " + state_final);

    }

    
}
