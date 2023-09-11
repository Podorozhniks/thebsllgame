using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public GameObject ball;  // The ball we want to spawn
    public float spawnTime = 2.0f;  // How often we want to spawn the ball
    public Vector3 spawnPosition; // The high position where balls should spawn from

    // Array of scoring colors
    private Color[] scoringColors =
    {
        new Color(0, 0, 1), // Blue
        new Color(1, 0, 0), // Red
        new Color(0, 1, 0)  // Green
    };

    void Start()
    {
        // Start calling the Spawn function repeatedly after a delay of spawnTime and then every spawnTime seconds
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    void Spawn()
    {
        // Instantiate a ball at the designated spawn position
        GameObject newBall = Instantiate(ball, spawnPosition, Quaternion.identity);

        // Assign a tag to the ball
        newBall.tag = "Ball";

        // Assign one of the scoring colors to the ball randomly
        Renderer rend = newBall.GetComponent<Renderer>();
        rend.material.color = scoringColors[Random.Range(0, scoringColors.Length)];
    }
}




