using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator)), RequireComponent(typeof(InputManager))]
public class PlayerAtack : MonoBehaviour
{
    public string[] skillTags = new string[] { "Slash", "Push" };
    Animator animator;
    InputManager input;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        input = GetComponent<InputManager>();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < skillTags.Length; ++i)
        {
            
            animator.SetBool(skillTags[i], input.keyPressed[i]);
        }
    }
}
