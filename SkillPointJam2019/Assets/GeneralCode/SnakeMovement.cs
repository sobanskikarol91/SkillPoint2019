
using System;
using UnityEngine;

public class SnakeMovement : MonoBehaviour
{
    public float speed = 1;
    public float minTimeToChangeDirection = 2;
    public float maxTimeToChangeDirection = 4;

    float timeLeftToChangeDirection;
    float timeToGainDirection = 10;
    public Transform[] nodes;

    private Vector2 currentDirection;
    private Vector2 targetDirection;
    private bool isLerping = true;
    private float timeStartedLerping;

    private void Awake()
    {
        SetRandomTimeToChangeDirection();
        ChooseTargetDirection();
    }

    void Update()
    {
        Move();

        if (isLerping)
            LerpToTarget();

        CheckTimeToChangeDirection();
    }

    private void Move()
    {
        Debug.Log("CD" + currentDirection);
        nodes[0].Translate((Vector3)currentDirection * speed * Time.deltaTime);
        //MoveNodes();
    }

    private void CheckTimeToChangeDirection()
    {
        timeLeftToChangeDirection -= Time.deltaTime;

        if (timeLeftToChangeDirection <= 0)
        {
            Debug.Log("ChangeTimeToNewDirection");
            SetRandomTimeToChangeDirection();
            ChooseTargetDirection();
            StartLerp();
        }
    }

    private void SetRandomTimeToChangeDirection()
    {
        timeLeftToChangeDirection = 2;
        //timeLeftToChangeDirection = UnityEngine.Random.Range(minTimeToChangeDirection, maxTimeToChangeDirection);
    }

    void MoveNodes()
    {
        for (int i = 1; i < nodes.Length - 1; i++)
        {
            // nodes[i].position = nodes[i-1].
        }
    }

    void ChooseTargetDirection()
    {
        targetDirection = UnityEngine.Random.insideUnitCircle;
        Debug.Log("New Target Direction:" + targetDirection);
    }


    void StartLerp()
    {
        isLerping = true;
        timeStartedLerping = Time.time;
    }

    void LerpToTarget()
    {
        float timeSinceStarted = Time.time - timeStartedLerping;
        float percentageComplete = timeSinceStarted / timeToGainDirection;

        currentDirection = Vector3.Lerp(currentDirection, targetDirection, percentageComplete);
        transform.rotation =

       // currentDirection.Normalize();

        if (percentageComplete >= 1)
            isLerping = false;
    }
}
