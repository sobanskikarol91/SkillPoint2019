using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleSpawner : MonoBehaviour
{
    public enum Color {Yellow=0,Green=1,Red=2,Blue=3}
    public Color color;
    public GameObject[] ballPrefabs;
    public Transform spawnPosition;

    private AudioSource audioSource;

    private void Awake()
    {
        audioSource =  GetComponent<AudioSource>();
        color = transform.root.GetComponent<Cryon>().cryonColor;
    }

    private void OnEnable()
    {
        Spawn();
    }

    private void Spawn()
    {
        audioSource.Play();
        Vector2 hitPosition = Random.insideUnitCircle * 5f + (Vector2)spawnPosition.position;
        GameObject spawned = Instantiate(ballPrefabs[(int)color], transform.position, Quaternion.identity, null);
        spawned.GetComponent<BubbleBall>().endPosition = hitPosition;
        Debug.Log(transform.parent.name);
    }
}
