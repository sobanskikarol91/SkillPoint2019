using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleBall : MonoBehaviour
{
    public Vector2 endPosition;
    public float moveSpeed;
    public GameObject spawnBubble;

    public void FixedUpdate()
    {
        //transform.position = Vector2.Lerp(transform.position, endPosition, moveSpeed);
        transform.position = Vector2.MoveTowards(transform.position, endPosition, moveSpeed);
        if(Vector2.Distance(transform.position, endPosition) < Mathf.Epsilon)
        {
            Instantiate(spawnBubble, transform.position, Quaternion.Euler(0,0,Random.value*360));
            Destroy(this.gameObject);
        }
    }
}
