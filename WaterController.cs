using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// This script is attached to the watering can in Wangari's scene
// This script is keeping track of the Z axis of the watering can
// If there the watering can is tipped...
// Water comes out of the watering can


// Tips to selves:
// Don't use steam VR objects as colliders
// Child invisible sphere to right hand to use as collider

//TODO: water
//make splashy sounds
//make sure they don't collide with each other - do this by writing code to ignore if the prefab collides with its self

//TODO: seed becoming a tree
//Create a variable to keep track of how many water prefabs fall on seed
//Use this variable to control the header/time marker of the timeline
//Make the water fall more slowly somehow
//1. Use the Timeline to enable and disable assets over time. 
//2. Attach the timeline to the game object Seed. 
//3. Use a script to enable the timeline, which in code is called the PlayableDirector.
//4. use script to keep track of the head (time marker) in the (animation?) timeline as a variable that can increment the timeline
//5. and control the timescrubber variable based on how much water has been instantiated by the watering can/come out of the watering can.
//(To fade, we can slowly change things using lerp() = change X between A and B multiplied by time)
//(Do a coroutine that lasts a few seconds to pause on first seed asset)



public class WaterController : MonoBehaviour
{

    public GameObject this_hand_final;

    private float canZaxis2_final;
    
    public GameObject Drop_final;
    public Transform waterSpawn_final;
    public float speed_final;

    public GameObject seed_final;

    private int holeState_final;
    private dropSeed_final seedScript_final;




    void Start()
    {

        seedScript_final = seed_final.GetComponent<dropSeed_final>();
        
    }

    void Update()
    {
        holeState_final = seedScript_final.state_final;
        canZaxis2_final = transform.rotation.eulerAngles.z;
        //Debug.Log("Game state: " + seedScript.state);
   
    }

    // iIf hand collides with this game object (watering can)
    private void OnTriggerStay(Collider other)
    {
        canZaxis2_final = transform.rotation.eulerAngles.z;

        if (holeState_final == 1)
            Debug.Log("the if statement for holestate == 1 is working");
        {
            if (other.tag == "hand")
            {
                Debug.Log("hand collided with watering can");

                if (canZaxis2_final <= 300f && canZaxis2_final >= 250f)
                {
                    Debug.Log("tipping in range, pour water");
                    pourtheWater();
                }
            }
        }     
    }

    private void pourtheWater()
    {
        // Let the player pour water anywhere
        var water = (GameObject)Instantiate(
            Drop_final,
            waterSpawn_final.position,
            waterSpawn_final.rotation);

        water.GetComponent<Rigidbody>().velocity = water.transform.forward * speed_final;
        Destroy(water, 2.0f);

        // TODO: Look into state manager  here...
        Debug.Log("I'm pouring water and rendered obj holeState is: " + holeState_final);

    }
}