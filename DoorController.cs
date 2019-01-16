using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;


// This script is attached to the door in Wangari's scene
// This script is using the UnityEngine.Video class
// This script disables Wangari's environment and enables Rachel's environment and the TV in her study
// When either player's hand collides with the door.

public class DoorController : MonoBehaviour
{

    public GameObject WangariEnvironment;
    public GameObject RachelEnvironment;
    public Material Rachel_Default_sky;

    public GameObject Tv_Video;
    public VideoPlayer Tv_Video_Component; 

    void Start()
    {
        Tv_Video_Component = Tv_Video.GetComponent<VideoPlayer>();
    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "hand")
        {
            Debug.Log("something collided with door");


            RachelEnvironment.SetActive(true);
            Tv_Video_Component.enabled = true; 


            WangariEnvironment.SetActive(false);
            RenderSettings.skybox = Rachel_Default_sky;
        }
        else
        {
            WangariEnvironment.SetActive(true);
        }
    }
}

    