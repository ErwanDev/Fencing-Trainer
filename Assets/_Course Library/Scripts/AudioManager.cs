using UnityEngine;
using System.Collections;
using UnityEngine.XR.Interaction.Toolkit;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource; // The AudioSource component
    public AudioClip[] audioClips; // Array of audio clips to play
    public RectTransform arrowImage; // The arrow image to show with audio clip 2
    public RectTransform leftFootE; // Left foot (E) to show with audio clip 3
    public RectTransform rightFootE; // Right foot (E) to show with audio clip 3
    public RectTransform leftFootA; // Left foot (A) to show with audio clip 4
    public RectTransform rightFootA; // Right foot (A) to show with audio clip 4
    public RectTransform leftFootL; // Left foot (L) to show with audio clip 5
    public RectTransform rightFootL; // Right foot (L) to show with audio clip 5

    public Transform dummy;

    public Transform target;

    public Vector3 dummyPosition1 = new Vector3(-10.6334105f,2.00732088f,2.13599992f);
    public Vector3 dummyPosition2 = new Vector3(-10.6334105f,2.00732088f,1.38100004f);
    public Vector3 dummyPosition3 = new Vector3(-10.6334105f,2.00732088f,0.866999984f);

    private GameObject player;
    private GameObject carp;
    private GameObject sword;
    private XRGrabInteractable grabInteractable;
    private float distance;
    private bool triggered;

    private void Start()
    {
        // Ensure the arrow image and foot UI elements are initially inactive
        if (arrowImage != null)
            arrowImage.gameObject.SetActive(false);

        if (leftFootE != null)
            leftFootE.gameObject.SetActive(false);

        if (rightFootE != null)
            rightFootE.gameObject.SetActive(false);

        if (leftFootA != null)
            leftFootA.gameObject.SetActive(false);

        if (rightFootA != null)
            rightFootA.gameObject.SetActive(false);

        if (leftFootL != null)
            leftFootL.gameObject.SetActive(false);

        if (rightFootL != null)
            rightFootL.gameObject.SetActive(false);

        player = GameObject.Find("Main Camera");
        carp = GameObject.Find("Carpet (3)");
        sword = GameObject.Find("Fencing Foil Sword");
        grabInteractable = sword.GetComponent<XRGrabInteractable>();
        triggered = false;
    }

    private void Update() {
        distance = (player.transform.position-carp.transform.position).sqrMagnitude;
        if (distance<3*3 && !triggered && grabInteractable.isSelected) {
            StartCoroutine(PlayAudioAndShowUI());
            triggered = true;
        }
    }

    IEnumerator PlayAudioAndShowUI()
    {
        for (int i = 0; i < audioClips.Length; i++)
        {

            if (audioClips[i] != null)
            {

                float waitTime = audioClips[i].length;
                float secondDelay = 3f;

                if (i == 4 || i == 7) {
                    secondDelay = 5f;
                }

                if (i == 5 || i == 8 || i == 9) {
                    secondDelay = 7f;
                }

                Debug.Log("Playing audio clip: " + audioClips[i].name);

                // Handle UI elements for specific audio clips
                if (i == 1 && arrowImage != null)
                {
                    Debug.Log("Showing arrow image");
                    arrowImage.gameObject.SetActive(true);
                }
                else if (i == 2) 
                {
                    Debug.Log("Showing extension UI elements");
                    if (leftFootE != null)
                        leftFootE.gameObject.SetActive(true);

                    if (rightFootE != null)
                        rightFootE.gameObject.SetActive(true);


                    if (dummy != null) {
                        dummy.position = dummyPosition1;
                    }

                }
                else if (i == 5)
                {
                    Debug.Log("Showing advance UI elements");
                    if (leftFootA != null)
                        leftFootA.gameObject.SetActive(true);

                    if (rightFootA != null)
                        rightFootA.gameObject.SetActive(true);

                    if (dummy != null) {
                        dummy.position = dummyPosition2;
                    }
                } else if (i == 7) {
                    if (dummy != null) {
                        dummy.position = dummyPosition3;
                    }
                }
                else if (i == 9)
                {
                    Debug.Log("Showing flick UI elements");
                    if (leftFootE != null)
                        leftFootE.gameObject.SetActive(true);

                    if (rightFootE != null)
                        rightFootE.gameObject.SetActive(true);

                    if (dummy != null) {
                        dummy.position = dummyPosition1;
                    }

                }

                // Play the current audio clip
                audioSource.clip = audioClips[i];
                audioSource.Play();

                yield return new WaitForSeconds(waitTime);

                // Wait an additional second Delay
                yield return new WaitForSeconds(secondDelay);

                if (i == 4) {
                    target.localScale = new Vector3(0.0500000007f,0.0500000007f,0.0500000007f);
                    yield return new WaitForSeconds(3f);
                } else if (i == 8) 
                {
                    Debug.Log("Showing lunge UI elements");
                    if (leftFootL != null)
                        leftFootL.gameObject.SetActive(true);

                    if (rightFootL != null)
                        rightFootL.gameObject.SetActive(true);

                    yield return new WaitForSeconds(7f);

                }

                // Hide the current UI elements after they are shown
                if (i == 1 && arrowImage != null) // Hide arrow image
                {
                    Debug.Log("Hiding arrow image");
                    arrowImage.gameObject.SetActive(false);
                }
                else if (i == 2) // Hide leftFootE and rightFootE
                {
                    Debug.Log("Hiding extension UI elements");
                    if (leftFootE != null)
                        leftFootE.gameObject.SetActive(false);

                    if (rightFootE != null)
                        rightFootE.gameObject.SetActive(false);
                }
                else if (i == 6) 
                {
                    Debug.Log("Hiding advance UI elements");
                    if (leftFootA != null)
                        leftFootA.gameObject.SetActive(false);

                    if (rightFootA != null)
                        rightFootA.gameObject.SetActive(false);
                }
                else if (i == 8) 
                {
                    Debug.Log("Hiding lunge UI elements");
                    if (leftFootL != null)
                        leftFootL.gameObject.SetActive(false);

                    if (rightFootL != null)
                        rightFootL.gameObject.SetActive(false);
                }
                else if (i == 9)
                {
                    Debug.Log("Hiding flick UI elements");
                    if (leftFootE != null)
                        leftFootE.gameObject.SetActive(false);

                    if (rightFootE != null)
                        rightFootE.gameObject.SetActive(false);
                }
            }
            else
            {
                Debug.LogWarning("Audio clip at index " + i + " is null.");
            }
        }
    }
}
