using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowBubble : MonoBehaviour
{
    float slowFactor = 10f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Rigidbody2D player = collision.gameObject.GetComponent<Rigidbody2D>();
        player.drag = player.drag / slowFactor;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Rigidbody2D player = collision.gameObject.GetComponent<Rigidbody2D>();
        player.drag = player.drag * slowFactor;
    }
}
