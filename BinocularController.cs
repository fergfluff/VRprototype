using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;


// This script is attached to the binoculars of Rachel Carson's scene
// This script is using the UnityEngine.Video class
// This script is keeping track of a collision between the binoculars and the goggles
// When there is a collision...
// The binoculars play a video as a skybox, play the video's sound, play Rachel's audio.
// And all of the game object's disappear and there is ocean audio
// Otherwise  if it leaves the collision, the video disappears
// If there is another collision, it restarts.


// Notes to selves on how to play a video in Unity
// Drag a video file into the unity project folders
// Make an empty game object
// Add a video player component to it
// Drag video file you added to the project into the component
// Set the mode to render texture
// Make a blank render texture in the project
// Go to video player component and select render texture you just made
// Make new blank material
// Drag the render texture you just made into this new material's albido
// Make a new plane / game object to display video on
// Drag the material you just made onto the plane
// Be sure that the video player's render texture is the same size as the video file.
// You can see the render texture's size by selecting it and looking in the inspector.

//Essentially:
//The plane gets its material from the material you made
//The material gets its albido from the render texture you made
//The render texture gets its image from the video file



public class BinocularController : MonoBehaviour
{
    // Oculus VR goggles
    public GameObject goggles_final;

    //videos
    public GameObject videoScreen_final;
    public GameObject videoScreenInstance_final;

    public GameObject oceanVideoPlayer;
    public VideoPlayer oceanVideoPlayerComponent;

   // public GameObject pesticidesVideoPlayer;
   // public VideoPlayer pesticidesVideoPlayerComponent;

    public Material blueSky_final;
    public Material oceanSky_final;
    //public Material pesticideSky_final;

    public GameObject scene_final;

    AudioSource underwaterSound_final;
    // AudioSource pesticidesSound;
 


    private void Start()
    {
        oceanVideoPlayerComponent = oceanVideoPlayer.GetComponent<VideoPlayer>();
        underwaterSound_final = oceanVideoPlayer.GetComponent<AudioSource>();

        //pesticidesVideoPlayerComponent = pesticidesVideoPlayer.GetComponent<VideoPlayer>();
        //underwaterSound_final = pesticidesVideoPlayer.GetComponent<AudioSource>();

    }


    void Update()
    {
        Debug.Log(underwaterSound_final);
    }


    private void OnTriggerEnter(Collider other)

    {
        if (other.tag == "goggles")
        {
            Debug.Log("goggles collided with binoculars");

            //We need to enable the entire component because later we need to disable it in order to
            //completely stop the rendering of the video, so that it can successfully restart upon a new collision
            //without this, the video isn't restarting, it is picking up where it left off
            oceanVideoPlayerComponent.enabled = true;
            
            //Change the world's skybox to the oceanSky
            RenderSettings.skybox = oceanSky_final;

            //Set inactive the empty GameObject Scene that holds all the other game objects
            scene_final.SetActive(false);

            //Play the ocean sound
            underwaterSound_final.Play();

        }
    }

    private void OnTriggerExit(Collider other)
    {
        // if (other.tag == "Wangari")
        if (other.tag == "goggles")
        {
            Debug.Log("goggles exited collision with binoculars");

            //Disable component so it can be enabled later
            oceanVideoPlayerComponent.enabled = false;

            RenderSettings.skybox = blueSky_final;
            scene_final.SetActive(true);
            underwaterSound_final.Stop();
            Debug.Log(underwaterSound_final.isPlaying);

        }
    }
}

    

