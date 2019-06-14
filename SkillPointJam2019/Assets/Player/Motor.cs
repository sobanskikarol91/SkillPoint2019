using UnityEngine;
using System.Collections;

/// Moves an object forward
public class Motor : MonoBehaviour
{

    public new Rigidbody2D rigidbody;
    public float movementSpeed;


    // Use this for initialization
    void Awake()
    {
        if (rigidbody == null)
            rigidbody = GetComponentInParent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(rigidbody)
            rigidbody.AddForce(
                new Vector2(transform.up.x, transform.up.y)
                * movementSpeed
        );
    }

}