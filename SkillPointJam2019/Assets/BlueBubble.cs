using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueBubble : MonoBehaviour
{
    float slowFactor = 1.75f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Rigidbody2D player = collision.gameObject.GetComponent<Rigidbody2D>();
        if(player!=null)
            player.drag = player.drag * slowFactor;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Rigidbody2D player = collision.gameObject.GetComponent<Rigidbody2D>();
        if (player != null)
            player.drag = player.drag / slowFactor;
    }
}
