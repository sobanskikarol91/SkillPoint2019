using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] public int playerId = -1;
    string GetPadSuffix() { return playerId == -1 ? "" : "_Pad" + playerId; }

    [SerializeField] string[] keyInputNames = new string[] { "Fire1", "Fire2" };

    [SerializeField] string xAxisCode = "Horizontal";
    [SerializeField] string yAxisCode = "Vertical";
    [SerializeField] string xAxisDirCode = "Horizontal";
    [SerializeField] string yAxisDirCode = "Vertical";

    public float minimalPositionInputStrength = 0.1f;
    public float minimalDirectionInputStrength = 0.1f;
    [System.NonSerialized] public Vector2 positionInput;
    [System.NonSerialized] public bool atMove;
    [System.NonSerialized] public Vector2 directionInput;
    [System.NonSerialized] public bool atAim;

    [System.NonSerialized] public bool[] keyPressed;

    private void Start()
    {
        keyPressed = new bool[keyInputNames.Length];
    }

    private void Update()
    {
        Vector2 v = new Vector2(Input.GetAxisRaw(xAxisCode + GetPadSuffix()), Input.GetAxisRaw(yAxisCode + GetPadSuffix())  );
        atMove = v.sqrMagnitude > minimalPositionInputStrength * minimalPositionInputStrength;
        if (atMove)
            positionInput = v.normalized;

        if (playerId == -1)
            v = (Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position);
        else
            v = v = new Vector2(
                Input.GetAxisRaw(xAxisDirCode + GetPadSuffix()),
                Input.GetAxisRaw(yAxisDirCode + GetPadSuffix())
                );

        atAim = v.sqrMagnitude > minimalDirectionInputStrength * minimalDirectionInputStrength;
        if (atAim)
            directionInput = v.normalized;
        else
            directionInput = positionInput;

        for (int i = 0; i < keyInputNames.Length; ++i)
            keyPressed[i] = Input.GetButton(keyInputNames[i] + GetPadSuffix());
    }

}
