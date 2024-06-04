using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
 
    public delegate void Collided();

    public static event Collided OnCollided;

    private void OnTriggerEnter(Collider other) {

        if (other.CompareTag("Fencing Foil Sword")) {

            Debug.Log("Collision Detected with Sword and target");

            if (OnCollided != null) {
                Debug.Log("Calling Event");

                OnCollided();
            }

        }

    }

}
