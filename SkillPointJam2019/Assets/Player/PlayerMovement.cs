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
    public bool rotateToSkillDirection = false;
    bool rotateSkillDirectionLastFrame = true;
    Vector2 directionInputRemembered;
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
        if (rotateToDirection)
        {

            if (rotateToSkillDirection )
            {
                if(!rotateSkillDirectionLastFrame)
                    directionInputRemembered = input.directionInput;

                input.positionInput = directionInputRemembered;
            }

            rb.rotation = Mathf.LerpAngle(rb.rotation, 
                Vector2.SignedAngle(Vector2.up, rotateToSkillDirection ? directionInputRemembered : input.positionInput), 
                rotationSpeed);

        }

        rotateSkillDirectionLastFrame = rotateToSkillDirection;
    }
}
