using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth;

    private int currentHealth;
    private Collider collider;
    private PlayMakerFSM fsm;


    private void Awake()
    {
        currentHealth = maxHealth;
        fsm = GetComponent<PlayMakerFSM>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Arena")
        {
            Debug.Log("fsdfdsa");
            Death();
        }
    }

    void Death()
    {
        fsm.SendEvent("Death");
        GameManager.instance.Death(this);
        currentHealth--;
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