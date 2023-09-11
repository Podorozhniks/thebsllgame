using UnityEngine;

public class SpawnBalls : MonoBehaviour
{
    public GameObject ball;  // The ball we want to spawn
    public float spawnTime = 2.0f;  // How often we want to spawn the ball

    void Start()
    {
        // Start calling the Spawn function repeatedly after a delay of spawnTime and then every spawnTime seconds
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    void Spawn()
    {
        // Instantiate a ball at the spawner's position
        GameObject newBall = Instantiate(ball, transform.position, Quaternion.identity);

        // Change the ball's color randomly
        Renderer rend = newBall.GetComponent<Renderer>();
        rend.material.color = new Color(Random.value, Random.value, Random.value);
    }
}

