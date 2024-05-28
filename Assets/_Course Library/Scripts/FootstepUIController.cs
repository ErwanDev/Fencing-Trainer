using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FootstepUIController : MonoBehaviour
{
    public GameObject initialStanceUI; // Assign in the Inspector
    public GameObject rightFootForwardUI; // Assign in the Inspector

    private void Start()
    {
        // Initially, show the initial stance and hide the right foot forward stance
        initialStanceUI.SetActive(true);
        rightFootForwardUI.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<XRController>() != null) // Check if the XR controller is entering the trigger
        {
            initialStanceUI.SetActive(false);
            rightFootForwardUI.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<XRController>() != null) // Check if the XR controller is exiting the trigger
        {
            initialStanceUI.SetActive(true);
            rightFootForwardUI.SetActive(false);
        }
    }
}
