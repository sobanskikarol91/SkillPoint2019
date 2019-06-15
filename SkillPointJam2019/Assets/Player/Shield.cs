using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public int usageCount = 3;
    public bool IsBlocking;
    InputManager input;
    public SpriteRenderer playerShield;
    public Sprite[] shieldSprites;

    [SerializeField] AudioClip useSnd;

    public void Start()
    {
        input = GetComponent<InputManager>();
    }

    void ShieldTaken(BubbleSpawner.Color color)
    {
        playerShield.sprite = shieldSprites[(int)color];
        usageCount = 3;
    }

    public void ShieldUse()
    {
        IsBlocking = true;
        usageCount--;
    }

    public void ShieldUsed()
    {
        AudioSource.PlayClipAtPoint(useSnd, transform.position);

        IsBlocking = false;
        usageCount--;
        if (usageCount < 1)
            playerShield.sprite = null;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Bubble" && input.keyPressed[4])
        {
            BubbleSpawner.Color color = collision.gameObject.GetComponentInParent<Bubble>().color;
            collision.gameObject.GetComponentInParent<Bubble>().Disappear();
            ShieldTaken(color);
        }
    }
}
