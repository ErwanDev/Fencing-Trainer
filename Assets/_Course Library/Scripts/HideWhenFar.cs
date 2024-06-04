using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideWhenFar : MonoBehaviour
{
    // retrieve the player GO
    public Vector3 distance;
    void Start() { 
        player = GameObject.Find("Player");
        carp = GameObject.Find("carp");
    }

    void Update() { 
        //distance = (player.transform.position-carp.transform.position);
    /*
        // the player is within a radius of 3 units to this game object
    foreach (Transform child in transform) {
        if ((player.transform.position-this.transform.position).sqrMagnitude<3*3) {
            child.gameObject.SetActive(true);
        }
        else {
            child.gameObject.SetActive(false);
        }
    }*/
    }
    private GameObject player;
    private GameObject carp;
}
