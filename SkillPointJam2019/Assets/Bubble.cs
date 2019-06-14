using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    public BubbleSpawner.Color color;
    public float lifeTime = 3f;
    private Animator animator;

    public void Start()
    {
        animator = GetComponent<Animator>();
        Invoke("Disappear", lifeTime);
    }

    public void Disappear()
    {
        animator.SetTrigger("Disappear");
    }

    public void Disappeared()
    {
        Destroy(this.gameObject);
    }
}
