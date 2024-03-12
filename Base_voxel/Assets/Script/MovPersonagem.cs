using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovPersonagem : MonoBehaviour
{
    public float speed = 5.0f;
    public float jumpHeight = 1.0f;
    public float gravity = -19.6f;

    private CharacterController controller;
    private Vector3 velocity;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Check if the character is grounded
        bool isGrounded = controller.isGrounded;

        // Check for movement input
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate movement direction
        Vector3 moveDirection = transform.right * horizontalInput + transform.forward * verticalInput;

        // Apply movement speed
        controller.Move(moveDirection * speed * Time.deltaTime);

        // Apply gravity
        if (!isGrounded)
        {
            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
        }

        // Jumping
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2.0f * gravity);
        }
    }
}
