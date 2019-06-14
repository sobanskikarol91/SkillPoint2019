using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D)), RequireComponent(typeof(InputManager))]
public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed;
    [Range(0.0f, 1.0f)] public float rotationSpeed = 1.0f;
    public bool moveToDirection = true;
    public bool rotateToDirection = true;
    Rigidbody2D rb;
    InputManager input;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        input = GetComponent<InputManager>();
    }

    private void FixedUpdate()
    {
        if(moveToDirection && input.atMove)
            rb.AddForce(input.positionInput * movementSpeed);
        if(rotateToDirection)
            rb.rotation = Mathf.LerpAngle(rb.rotation, Vector2.SignedAngle(Vector2.up, input.positionInput), rotationSpeed);
    }
}
