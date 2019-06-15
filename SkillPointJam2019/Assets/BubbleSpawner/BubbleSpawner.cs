using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSpawner : MonoBehaviour
{
    public enum Color {Yellow=0,Green=1,Red=2,Blue=3}
    public Color color;
    public GameObject ballPrefab;
    public float spawnProbability = 0.1f;
    public static float areaDiameter = 17f;

    private AudioSource audioSource;

    private void Awake()
    {
      audioSource =  GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Random.value < spawnProbability)
            Spawn();
    }

    private void Spawn()
    {
        audioSource.Play();
        Vector2 hitPosition = Random.insideUnitCircle * areaDiameter;
        GameObject spawned = Instantiate(ballPrefab, transform.position, Quaternion.identity, transform.parent);
        spawned.GetComponent<BubbleBall>().endPosition = hitPosition;
    }
}
