﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiCameraController : MonoBehaviour
{
    public List<Transform> targets = new List<Transform>();
    
    [Range(0.0f, 10.0f)]
    public float learpFactor = 10.0f;

    [Space]
    public float minScaleDistance;
    public float scaleFactor;

    [Space]
    float initialOffsetRotation;
    float initialOffsetScale;


    float maxDist;

    bool s = false;
    Vector3 GetAveragePosition()
    {
        Vector3 sum = Vector2.zero;
        int i = 0;
        foreach (var it in targets)
            if(it != null)
        {
            sum += it.position;
            ++i;
        }

        s = i == 0;
        if (!s)
            sum = sum / i;

        return sum;
    }

    // Use this for initialization
    void Start()
    {
        initialOffsetRotation = transform.rotation.eulerAngles.z;
        initialOffsetScale = Camera.main.orthographicSize;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float offsetScale = initialOffsetScale + shakeScaleInfluence;

        Vector3 averagePosition = GetAveragePosition();
        Vector3 middlePos = averagePosition;
        if (!s)
        {
            float z = transform.position.z;
            transform.position = transform.position + (middlePos - transform.position) * learpFactor * Time.deltaTime
                + (Vector3)shakePositionInfluence;
            transform.position = new Vector3(transform.position.x, transform.position.y, z);
        }

        maxDist = 0;
        int i = 0;
        foreach (var it in targets)
        {
            if (it != null)
            {
                maxDist = Mathf.Max((averagePosition - it.position).sqrMagnitude, maxDist);
            }
            ++i;
        }
        transform.rotation = Quaternion.Euler(0, 0, initialOffsetRotation + shakeRotationInfluence) ;
        Camera.main.orthographicSize = offsetScale * (1 + (maxDist - minScaleDistance * minScaleDistance) * scaleFactor) + shakeScaleInfluence;
    }
    private void FixedUpdate()
    {
        shakePositionInfluence *= shakePositionDamping;
        shakeRotationInfluence *= shakeRotationDamping;
        shakeScaleInfluence *= shakeScaleDamping;
    }


    /// Screan shakes
    /// 
    [Range(0.0f, 1.0f)]
    public float shakePositionDamping;
    Vector2 shakePositionInfluence;
    public void shakePosition(Vector2 shakePower)
    {
        shakePositionInfluence += shakePower;
    }

    [Range(0.0f, 1.0f)]
    public float shakeRotationDamping;
    float shakeRotationInfluence;
    public void shakeRotation(float shakePower)
    {
        shakeRotationInfluence += shakePower;
    }

    [Range(0.0f, 1.0f)]
    public float shakeScaleDamping;
    float shakeScaleInfluence;
    public void shakeScale(float shakePower)
    {
        shakeScaleInfluence += shakePower;
    }


}
