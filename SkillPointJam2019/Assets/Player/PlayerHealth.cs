using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth;
    public GameObject deathEffect;

    private int currentHealth;
    private Collider collider;
    private PlayMakerFSM fsm;


    private void Awake()
    {
        fsm = GetComponent<PlayMakerFSM>();
        collider = GetComponent<Collider>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("death");
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

    public void TurnOnGodMode()
    {
        fsm.SendEvent("GodMode");
    }
}