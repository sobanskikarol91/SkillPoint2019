using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    PlayerHealth[] playersHealth;
    public GameObject[] healthUI;

    private void Start()
    {
        playersHealth = new PlayerHealth[4];

        InputManager[] players = GameObject.FindObjectsOfType<InputManager>();
        foreach(InputManager player in players)
        {
            if (player.playerId == -1)
                playersHealth[3] = player.gameObject.GetComponent<PlayerHealth>();
            else
                playersHealth[player.playerId-1] = player.gameObject.GetComponent<PlayerHealth>();
        }

        for(int i=0; i<4; i++)
        {
            if (playersHealth[i] != null)
                healthUI[i].active = true;
        }
    }

    private void Update()
    {
        for (int i = 0; i < 4; i++)
        {
            if (playersHealth[i] != null)
            {
                Image[] HPs = healthUI[i].GetComponentsInChildren<Image>();
                for (int j = playersHealth[i].currentHealth; j < 5; j++)
                    HPs[j].enabled = false;
            }
        }
    }
}
