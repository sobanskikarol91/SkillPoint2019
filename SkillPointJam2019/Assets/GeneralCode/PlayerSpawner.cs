using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PlayerSpawner : MonoBehaviour
{
    public Transform[] spawnPoints;


    public void Spawn(Transform player)
    {
        int nr = Random.Range(0, spawnPoints.Length);
        player.transform.position = spawnPoints[nr].position;
    }
}