using UnityEngine;

public class GrabbableObject : MonoBehaviour
{
    private bool isGrabbed = false;
    private Transform grabber;

    public GameObject arrowImage;

    void Update()
    {
        if (isGrabbed && grabber != null)
        {
            transform.position = grabber.position;
            transform.rotation = grabber.rotation;
        }
    }

    public void Grab(Transform grabber)
    {
        this.grabber = grabber;
        isGrabbed = true;

        // Disable the arrow image when the sword is grabbed
        if (arrowImage != null)
        {
            arrowImage.SetActive(false);
        }
    }

    public void Release()
    {
        grabber = null;
        isGrabbed = false;

        if (arrowImage != null)
        {
            arrowImage.SetActive(true);
        }
    }

    public bool IsGrabbed()
    {
        return isGrabbed;
    }
}
