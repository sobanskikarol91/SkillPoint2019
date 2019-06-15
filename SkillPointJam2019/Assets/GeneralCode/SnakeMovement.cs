
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

    float mindistance = 10f;

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
        Transform currentPart, previousPart;

        for (int i = 1; i < nodes.Length; i++)
        {
            currentPart = nodes[i];
            previousPart = nodes[i - 1];

            float dis = Vector2.Distance(previousPart.position, currentPart.position);

            Vector2 newPos = previousPart.position;
            newPos.y = nodes[0].position.y;

            float T = Time.deltaTime * dis / mindistance * speed;

            if (T > 1f)
                T = 1f;

            currentPart.position = Vector3.Slerp(currentPart.position, newPos, T);
            currentPart.rotation = Quaternion.Slerp(currentPart.rotation, previousPart.rotation, T);
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
        Vector2 currentRotation = nodes[0].eulerAngles;
        currentRotation += (previousDirection - currentRotation);
        nodes[0].rotation = Quaternion.Euler(currentRotation);

        currentDirection.Normalize();

        if (percentageComplete >= 1)
            isLerping = false;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "SnakeBoundry")
        {
            Debug.Log("Boundry snake");
            currentDirection *= -1;
        }
    }
}
