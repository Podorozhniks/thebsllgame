using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    public float speed = 5.0f;  // The speed of our platform

    void Update()
    {
        // Get our input on the x axis
        float moveX = Input.GetAxis("Horizontal");

        // Create our movement vector
        Vector3 move = new Vector3(moveX, 0, 0);

        // Adjust movement by speed and time
        move = move * speed * Time.deltaTime;

        // Apply movement to our platform
        transform.position = transform.position + move;
    }
}
    
