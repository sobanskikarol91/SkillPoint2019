using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator)), RequireComponent(typeof(InputManager))]
public class PlayerAtack : MonoBehaviour
{
    public string[] skillTags = new string[] { "Slash", "Push" };
    Animator animator;
    InputManager input;
    Shield playerShield;
    Cryon playerCryon;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        input = GetComponent<InputManager>();
        playerShield = GetComponent<Shield>();
        playerCryon = GetComponent<Cryon>();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < skillTags.Length; ++i)
        {
            if (playerShield.usageCount < 1)
                input.keyPressed[2] = false;
            if (playerCryon.usageCount < 1)
                input.keyPressed[5] = false;

            animator.SetBool(skillTags[i], input.keyPressed[i]);
        }
    }
}
