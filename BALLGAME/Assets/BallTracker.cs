using UnityEngine;
using TMPro;  // Required for TextMeshProUGUI class

public class BallTracker : MonoBehaviour
{
    public int score = 0; // Score to track how many balls have passed the border.
    public TextMeshProUGUI scoreText;  // Reference to the TextMeshProUGUI component

    private void Start()
    {
        UpdateScoreText();
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the ball that entered the trigger has the correct tag.
        if (other.CompareTag("Ball"))
        {
            Color ballColor = other.GetComponent<Renderer>().material.color;

            // Check if the ball is one of the scoring colors.
            if (IsColorClose(ballColor, Color.blue) ||
                IsColorClose(ballColor, Color.red) ||
                IsColorClose(ballColor, Color.green))
            {
                score++; // Increment score.
                UpdateScoreText();
            }

            Destroy(other.gameObject); // Destroy the ball after checking its color.
        }
    }

    bool IsColorClose(Color a, Color b, float threshold = 0.1f)
    {
        float difference = Mathf.Abs(a.r - b.r) + Mathf.Abs(a.g - b.g) + Mathf.Abs(a.b - b.b);
        return difference < threshold;
    }

    void UpdateScoreText()
    {
        if (scoreText)
        {
            scoreText.text = "Score: " + score;
        }
        else
        {
            Debug.LogWarning("Score TextMeshPro UI not assigned in BallTracker.");
        }
    }
}




