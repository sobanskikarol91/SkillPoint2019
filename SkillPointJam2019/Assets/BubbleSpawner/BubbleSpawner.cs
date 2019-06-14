using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSpawner : MonoBehaviour
{
    public enum Color {Yellow,Green,Red,Blue}
    public Color color;
    public GameObject ballPrefab;
    public float spawnProbability = 0.1f;
    public static float areaDiameter = 17f;

    private void Update()
    {
        if (Random.value < spawnProbability)
            Spawn();
    }

    private void Spawn()
    {
        Vector2 hitPosition = Random.insideUnitCircle * areaDiameter;
        GameObject spawned = Instantiate(ballPrefab, transform.position, Quaternion.identity, transform.parent);
        spawned.GetComponent<BubbleBall>().endPosition = hitPosition;
    }
}
