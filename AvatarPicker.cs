using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

// This script is attached to the Player Gameobject 
// This script is using the UnityEngine.Networking class
// This script assigns the correct avatar to each player
// If the player is the server and local player, assign them Wangari with Steam VR objects and enable Rachel's avatar with no Steam VR objects
// If the player is the client, assign them Rachel with Steam VR objects and enable Rachel's avatar with no Steam VR objects
 

public class AvatarPicker : NetworkBehaviour
{
  
    void Start()
    {
        // If this machine is the server
        if (isServer)
        {
            // If it's the local player, and not the networked player
            if (isLocalPlayer)
            {
                // Set one avatar to true, and give it steam vr objects. Don't give this machine's steam vr objects to the other avatar!

                // Enable Wangari
                // Get a component within the game object this is on (the Player), called EmptyWangariScript, and set it true
                GetComponentInChildren<EmptyWangariScript>(true).gameObject.SetActive(true);

                //Define a variable called SteamVRObject as ...go find a game object called X
                GameObject SteamVRObject = GameObject.Find("SteamVRObjects");
                //Set the Player Object that this script is attached to, as the parent of the Steam VR Object.
                SteamVRObject.transform.SetParent(transform);

            }
            else
            {
                //enable Rachel
                GetComponentInChildren<EmptyRachelScript>(true).gameObject.SetActive(true);
  
            }

        }
        else
        {
            if (!isLocalPlayer)
            {
                // In this case, the machine is the networked machine...
                // So just enable Rachel's avatar but with no steam vr objects
                // And enable Wangari with the networked machine's steam vr objects

                // Enable wangari with no steam VR objects
                GetComponentInChildren<EmptyWangariScript>(true).gameObject.SetActive(true);

            }
            else
            {
                // Enable Rachel with steam VR objects
                GetComponentInChildren<EmptyRachelScript>(true).gameObject.SetActive(true);

                GameObject SteamVRObject = GameObject.Find("SteamVRObjects");
                SteamVRObject.transform.SetParent(transform);
            }
        }
    }
}