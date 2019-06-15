using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arena : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        PlayerHealth player = collision.GetComponent<PlayerHealth>();

        if (player)
            player.Death();
    }
}
