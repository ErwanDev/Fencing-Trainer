using UnityEngine;
using TMPro;
using UnityEngine.XR.Interaction.Toolkit;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public TextMeshProUGUI scoreText; 
    private int colorChangeCount = 0; 
    private XRController controller = null;

    void Awake()
    {
        controller = GetComponent<XRController>();
        // Ensure there is only one instance of the ScoreManager
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void IncrementScore()
    {
        colorChangeCount++;
        // Also send haptic feedback after score increase
        if (controller != null) controller.SendHapticImpulse(.5f, .5f);
        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + colorChangeCount;
        }
    }
}
