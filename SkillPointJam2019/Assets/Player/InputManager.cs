using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] string[] keyInputNames = new string[] { "Fire1", "Fire2" };
    [SerializeField] string xAxisCode = "Horizontal";
    [SerializeField] string yAxisCode = "Vertical";

    public float minimalPositionInputStrength = 0.1f;
    public float minimalDirectionInputStrength = 0.1f;
    [System.NonSerialized] public Vector2 positionInput;
    [System.NonSerialized] public bool atMove;
    [System.NonSerialized] public Vector2 directionInput;
    [System.NonSerialized] public bool atAim;

    [System.NonSerialized] public bool[] keyPressed = new bool[2];

    private void Update()
    {
        Vector2 v = new Vector2(Input.GetAxisRaw(xAxisCode), Input.GetAxisRaw(yAxisCode));
        atMove = v.sqrMagnitude > minimalPositionInputStrength * minimalPositionInputStrength;
        if (atMove)
            positionInput = v.normalized;

        v = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position);
        atAim = v.sqrMagnitude > minimalDirectionInputStrength * minimalDirectionInputStrength;
        if (atAim)
            directionInput = v.normalized;

        for (int i = 0; i < keyInputNames.Length; ++i)
            keyPressed[i] = Input.GetButton(keyInputNames[i]);
    }

}
