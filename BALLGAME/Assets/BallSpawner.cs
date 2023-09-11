using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public GameObject ball;  // The ball we want to spawn
    public Transform bottomBorder; // The bottom border where the balls should be checked
    public float spawnTime = 2.0f;  // How often we want to spawn the ball
    public Vector3 spawnPosition; // The high position where balls should spawn from

    // Array of scoring colors
    private Color[] scoringColors =
    {
        new Color(0, 0, 1), // Blue
        new Color(1, 0, 0), // Red
        new Color(0, 1, 0)  // Green
    };

    private int score = 0; // Store the score

    void Start()
    {
        // Start calling the Spawn function repeatedly after a delay of spawnTime and then every spawnTime seconds
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    void Update()
    {
        // Check if any ball has reached the bottom border and update the score
        foreach (GameObject ballObj in GameObject.FindGameObjectsWithTag("Ball"))
        {
            if (ballObj.transform.position.y < bottomBorder.position.y)
            {
                Color ballColor = ballObj.GetComponent<Renderer>().material.color;
                foreach (Color color in scoringColors)
                {
                    if (color == ballColor)
                    {
                        score++;
                        Debug.Log("Score: " + score);
                        break;
                    }
                }

                Destroy(ballObj);
            }
        }
    }

    void Spawn()
    {
        // Instantiate a ball at the designated spawn position
        GameObject newBall = Instantiate(ball, spawnPosition, Quaternion.identity);

        // Assign a tag to the ball
        newBall.tag = "Ball";

        // Determine if it's a scoring ball or just another random color
        bool isScoringBall = Random.value < 0.75f; // 75% chance to be a scoring ball, adjust as needed

        Renderer rend = newBall.GetComponent<Renderer>();
        if (isScoringBall)
        {
            // Assign one of the scoring colors to the ball randomly
            rend.material.color = scoringColors[Random.Range(0, scoringColors.Length)];
        }
        else
        {
            // Assign a random color that's not in the scoringColors array
            do
            {
                rend.material.color = new Color(Random.value, Random.value, Random.value);
            }
            while (IsScoringColor(rend.material.color));
        }
    }

    bool IsScoringColor(Color color)
    {
        foreach (Color scoringColor in scoringColors)
        {
            if (color == scoringColor)
            {
                return true;
            }
        }
        return false;
    }
}




