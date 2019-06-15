
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
    public float maxDist = 2;
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
        nodes[0].Translate((Vector3)currentDirection * speed * Time.deltaTime);
        MoveNodes();
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
        for (int i = 1; i < nodes.Length; i++)
        {
            Vector2 direction = nodes[i - 1].position - nodes[i].position;
            if (direction.sqrMagnitude > maxDist * maxDist)
            {
                nodes[i].position = (Vector2)nodes[i].position + direction.normalized * maxDist * Time.deltaTime;
            }
            else
                //nodes[i].Translate(direction * Time.deltaTime);
                nodes[i].position = (Vector2)nodes[i].position + direction * Time.deltaTime;
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

        Vector2 previousDirection = currentDirection;
        currentDirection = Vector3.Lerp(currentDirection, targetDirection, percentageComplete);
        // nodes[0].rotation = Quaternion.Euler(new Vector3(0, 0, Vector2.Angle(currentDirection, currentDirection -previousDirection)));

        // currentDirection.Normalize();

        if (percentageComplete >= 1)
            isLerping = false;
    }
}
