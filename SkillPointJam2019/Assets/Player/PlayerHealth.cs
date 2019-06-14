using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    public GameObject deathEffect;
    

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Arena")
            Death();
    }

    void Death()
    {
        GameManager.instance.Death(this);
        currentHealth--;
        Instantiate(deathEffect, transform);
    }

    public bool IsDeath()
    {
        return currentHealth == 0;
    }
}