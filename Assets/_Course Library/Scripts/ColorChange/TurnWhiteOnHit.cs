using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnWhiteOnHit : MonoBehaviour
{
    private bool hasBeenHit = false; // Track if the object has already been hit

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fencing Foil Sword") && !hasBeenHit)
        {
            GetComponent<MeshRenderer>().material.color = Color.white;
            ScoreManager.instance.IncrementScore();
            hasBeenHit = true; // Mark this object as having been hit
        }
    }
}
