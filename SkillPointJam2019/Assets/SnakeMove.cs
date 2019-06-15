using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SnakeMove : MonoBehaviour
{
    public float speed = 1;

    List<Vector2> historyPosition;
    public float SnakeRange = 19f;
    float timeLeftToChangeDirection;
    float timeToGainDirection = 15;
    public Transform[] nodes;
    private Vector2 currentDirection;
    private Vector2 targetDirection;
    private bool isLerping = true;
    private float timeStartedLerping;

    float mindistance = 10f;

    private void Start()
    {
        timeLeftToChangeDirection = 2f;
        ChooseTargetDirection();
        historyPosition = new List<Vector2>();
    }

    void FixedUpdate()
    {
        Move();

        LerpToTarget();

        CheckTimeToChangeDirection();

        if (Vector2.Distance(nodes[0].position, transform.parent.position) > SnakeRange)
        {
            Vector2 newDirection = Vector3.zero - nodes[0].position;
            newDirection.Normalize();
            currentDirection = newDirection;
            targetDirection = newDirection;
        }
    }

    private void Move()
    {
        historyPosition.Add(nodes[0].position);
        if (historyPosition.Count > nodes.Length * 10)
            historyPosition.RemoveAt(0);
        nodes[0].Translate((Vector3)currentDirection * speed * Time.deltaTime);
        MoveNodes();
    }

    private void CheckTimeToChangeDirection()
    {
        timeLeftToChangeDirection -= Time.deltaTime;

        if (timeLeftToChangeDirection <= 0)
        {
            timeLeftToChangeDirection = 2f;
            ChooseTargetDirection();
        }
    }

    void MoveNodes()
    {
        int frames = 10;

        for (int i = 1; i < nodes.Length; i++)
        {
            int index = i* frames;
            if (historyPosition.Count < i * frames)
            {
                index = (i - 1) * frames;
                return;
            }
            index++;
            nodes[i].position = historyPosition[historyPosition.Count - index];
        }
    }

    void ChooseTargetDirection()
    {
        targetDirection = UnityEngine.Random.insideUnitCircle;
    }

    void LerpToTarget()
    {
        float timeSinceStarted = Time.time - timeStartedLerping;
        float percentageComplete = timeSinceStarted / timeToGainDirection;

        Vector2 previousDirection = currentDirection;
        currentDirection = Vector3.Lerp(currentDirection, targetDirection, percentageComplete);
        nodes[0].GetChild(0).transform.right = currentDirection * 1 - (Vector2)nodes[0].position;

        currentDirection.Normalize();

        if (percentageComplete >= 1)
            isLerping = false;
    }
}
