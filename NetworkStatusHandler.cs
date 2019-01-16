using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;


// This enables all game objects when the client starts
// This script is using the UnityEngine.Networking class

public class NetworkStatusHandler : NetworkBehaviour
{

    public GameObject[] objects;

    public override void OnStartClient()
    {
        Debug.Log("on start network status handler");

        //when client connects, enable all the game objects

        StartCoroutine(startEverything());
    }

    public IEnumerator startEverything()
    {
        yield return new WaitForSeconds(3f);

        foreach (GameObject obj in objects)
        {
            Debug.Log("enable" + obj.name);
            obj.SetActive(true);
            yield return new WaitForSeconds(2f);
        }
    }

}
