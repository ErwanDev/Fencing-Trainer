using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DummyCollider : MonoBehaviour
{
    // Start is called before the first frame update
    public bool hitDetected = false;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Fencing Foil Sword"))
        {
            ScoreSystem.scoreCount += 1;
            hitDetected = true;
        }
    }
}
