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


    public void Death()
    {
        fsm.SendEvent("Death");
        GameManager.instance.Death(this);
        currentHealth--;
    }

    public bool IsDeath()
    {
        return currentHealth == 0;
    }
}