using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;  // Speed of the player movement

    private Rigidbody2D rb;
    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  // Get the Rigidbody2D component
    }

    void Update()
    {
        // Get input for horizontal and vertical movement
        float moveX = Input.GetAxisRaw("Horizontal");  // Arrow keys / WASD for horizontal movement
        float moveY = Input.GetAxisRaw("Vertical");    // Arrow keys / WASD for vertical movement

        movement = new Vector2(moveX, moveY).normalized;  // Normalize the movement vector to prevent faster diagonal movement
    }

    void FixedUpdate()
    {
        // Apply the movement to the Rigidbody2D
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}