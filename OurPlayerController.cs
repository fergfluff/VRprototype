using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


// This script allows the users to control the Player Game Object
// This script is using the UnityEngine.Networking class


public class OurPlayerController : NetworkBehaviour
{

    // Declare the three bridge game objects
    public GameObject BridgeHead;
    public GameObject BridgeRightHand;
    public GameObject BridgeLeftHand;

    // Declare the three steamvr game objects
    public GameObject SteamVRHead;
    public GameObject SteamVRRightHand;
    public GameObject SteamVRLeftHand;

    public GameObject StreamVrObject;

    [SyncVar]
    public GameObject seed;


    public Transform seedLocation;

    // In start define the steamvr objects by finding their scripts
    void Start()
    {

        if (isLocalPlayer)
        {
            gameObject.name = "LocalPlayer";

        }
        else
        {
            StreamVrObject.SetActive(false);
            gameObject.name = "NetworkedPlayer";
        }

    }

    // In update, each bridge object = corresponding steamvr object's position & again for the rotation
    void Update()
    {

        if (!isLocalPlayer)
            return;

        BridgeHead.transform.position = SteamVRHead.transform.position;
        BridgeRightHand.transform.position = SteamVRRightHand.transform.position;
        BridgeLeftHand.transform.position = SteamVRLeftHand.transform.position;

        BridgeHead.transform.rotation = SteamVRHead.transform.rotation;
        BridgeRightHand.transform.rotation = SteamVRRightHand.transform.rotation;
        BridgeLeftHand.transform.rotation = SteamVRLeftHand.transform.rotation;

    }
}

	

