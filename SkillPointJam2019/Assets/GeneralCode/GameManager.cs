using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class GameManager : MonoBehaviour
{
    public PlayerHealth[] players;
    public static GameManager instance;

    private PlayerSpawner playerSpawner;


    private void Awake()
    {
        playerSpawner = GetComponent<PlayerSpawner>();
        instance = this;
    }

    public void Death(PlayerHealth playerHealth)
    {
        if (playerHealth.IsDeath())
            GameOver();
        else
            playerSpawner.Spawn(playerHealth.transform);
    }

    private void GameOver()
    {

    }
}