using UnityEngine;

public class BallTracker : MonoBehaviour
{
    public int score = 0; // Score to track how many balls have passed the border.

    private void OnTriggerEnter(Collider other)
    {
        // Check if the ball that entered the trigger is blue, red, or green.
        if (other.CompareTag("Ball"))
        {
            Color ballColor = other.GetComponent<Renderer>().material.color;

            // Check if the ball is blue, red, or green.
            if (IsColorClose(ballColor, Color.blue) ||
                IsColorClose(ballColor, Color.red) ||
                IsColorClose(ballColor, Color.green))
            {
                score++; // Increment score.
                Debug.Log("Score: " + score);
                Destroy(other.gameObject); // Only destroy the ball if it's one of the scoring colors.
            }
        }
    }


    // Helper method to check if two colors are close to each other.
    bool IsColorClose(Color a, Color b, float threshold = 0.1f)
    {
        float difference = Mathf.Abs(a.r - b.r) + Mathf.Abs(a.g - b.g) + Mathf.Abs(a.b - b.b);
        return difference < threshold;
    }
}

