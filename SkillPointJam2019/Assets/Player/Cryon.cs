using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cryon : MonoBehaviour
{
    public int usageCount = 3;
    InputManager input;
    public SpriteRenderer playerCryon;
    public Sprite[] cryonSprites;

    public void Start()
    {
        input = GetComponent<InputManager>();
    }

    void CryonTaken(BubbleSpawner.Color color)
    {
        playerCryon.sprite = cryonSprites[(int)color];
        usageCount = 3;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Bubble" && input.keyPressed[5])
        {
            BubbleSpawner.Color color = collision.gameObject.GetComponentInParent<Bubble>().color;
            collision.gameObject.GetComponentInParent<Bubble>().Disappear();
            CryonTaken(color);
        }
    }
}
