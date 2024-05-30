using UnityEngine;
using System.Collections;

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


        // Start the coroutine to play audio and show UI elements
        StartCoroutine(PlayAudioAndShowUI());
    }

    IEnumerator PlayAudioAndShowUI()
    {
        for (int i = 0; i < audioClips.Length; i++)
        {
            if (audioClips[i] != null)
            {

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
                }
                else if (i == 6)
                {
                    Debug.Log("Showing extension UI elements");
                    if (leftFootA != null)
                        leftFootA.gameObject.SetActive(true);

                    if (rightFootA != null)
                        rightFootA.gameObject.SetActive(true);
                }
                else if (i == 8) 
                {
                    Debug.Log("Showing extension UI elements");
                    if (leftFootL != null)
                        leftFootL.gameObject.SetActive(true);

                    if (rightFootL != null)
                        rightFootL.gameObject.SetActive(true);
                }
                else if (i == 10)
                {
                    Debug.Log("Showing extension UI elements");
                    if (leftFootE != null)
                        leftFootE.gameObject.SetActive(true);

                    if (rightFootE != null)
                        rightFootE.gameObject.SetActive(true);
                }

                // Play the current audio clip
                audioSource.clip = audioClips[i];
                audioSource.Play();

                yield return new WaitForSeconds(audioClips[i].length);

                // Wait an additional 3 seconds
                yield return new WaitForSeconds(3f);

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
                    Debug.Log("Hiding extension UI elements");
                    if (leftFootA != null)
                        leftFootA.gameObject.SetActive(false);

                    if (rightFootA != null)
                        rightFootA.gameObject.SetActive(false);
                }
                else if (i == 8) 
                {
                    Debug.Log("Hiding extension UI elements");
                    if (leftFootL != null)
                        leftFootL.gameObject.SetActive(false);

                    if (rightFootL != null)
                        rightFootL.gameObject.SetActive(false);
                }
                else if (i == 10)
                {
                    Debug.Log("Hiding extension UI elements");
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
