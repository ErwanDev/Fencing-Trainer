using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnGreenOnHit : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        // Check if the triggering object has the tag "Fencing Foil Sword"
        if (other.CompareTag("Fencing Foil Sword"))
        {
            // Change the color to white
            GetComponent<MeshRenderer>().material.color = Color.green;
        }
    }
}
