using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerSpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject playerPrefab;

    private void Start()
    {
        int padCount = Input.GetJoystickNames().Length;
        for(int i = 0; i < padCount; i++)
        {
            Vector2 position = spawnPoints[Random.Range(0, spawnPoints.Length)].position;
            GameObject player = Instantiate(playerPrefab, position, Quaternion.identity);
            player.GetComponent<InputManager>().playerId = i;

            Shield shield = player.GetComponent<Shield>();
            shield.shieldColor = (BubbleSpawner.Color)i;
            shield.playerShield.sprite = shield.shieldSprites[i];

            Cryon cryon = player.GetComponent<Cryon>();
            cryon.cryonColor = (BubbleSpawner.Color)i;
            cryon.playerCryon.sprite = cryon.cryonSprites[i];
        }
    }

    public void Spawn(Transform player)
    {
        int nr = Random.Range(0, spawnPoints.Length);
        player.transform.position = spawnPoints[nr].position;
    }
}