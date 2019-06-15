using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    public BubbleSpawner.Color shieldColor;
    public int usageCount = 3;
    public bool IsBlocking;
    InputManager input;
    public SpriteRenderer playerShield;
    public Sprite[] shieldSprites;

    [SerializeField] AudioClip useSnd;

    public void Start()
    {
        input = GetComponent<InputManager>();
        //playerShield.sprite = shieldSprites[(int)shieldColor];
        //for (int i = 0; i < shieldSprites.Length; i++)
        //{
        //    if (playerShield.sprite == shieldSprites[i])
        //        shieldColor = (BubbleSpawner.Color)i;
        //}
    }

    void ShieldTaken(BubbleSpawner.Color color)
    {
        //shieldColor = color;
        //playerShield.sprite = shieldSprites[(int)color];
        //usageCount = 3;
    }

    public void ShieldUse()
    {
        IsBlocking = true;
        //usageCount--;
    }

    public void ShieldUsed()
    {
        AudioSource.PlayClipAtPoint(useSnd, transform.position);

        IsBlocking = false;
        //if (usageCount < 1)
        //    playerShield.sprite = null;
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
