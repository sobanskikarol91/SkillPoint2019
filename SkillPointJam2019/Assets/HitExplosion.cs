using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitExplosion : MonoBehaviour
{
    AreaEffector2D effector;
    BubbleSpawner.Color cryonColor;
    public GameObject explosionEffect;
    public GameObject hitEffect;

    void Start()
    {
        effector = GetComponent<AreaEffector2D>();
        cryonColor = GetComponentInParent<Cryon>().cryonColor;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<InputManager>() == null)
            return;
        Shield enemyShield = transform.root.GetComponent<Shield>();
        Vector2 collisionPoint = (collision.gameObject.transform.root.position + transform.root.position) / 2;
        if (enemyShield.shieldColor == cryonColor && !enemyShield.IsBlocking)
        {
            Instantiate(explosionEffect, collisionPoint, Quaternion.identity);
        }
        else
        {
            Instantiate(hitEffect, collisionPoint, Quaternion.identity);
        }
    }
}
