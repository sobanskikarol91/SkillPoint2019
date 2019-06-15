using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorHitEffect : MonoBehaviour
{
    public float ExplosionRadius;
    public float explosionForce;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if( collision.GetComponent<HitExplosion>() )
        {
            var coll = Physics2D.OverlapCircleAll(transform.position, ExplosionRadius);
            Debug.Log("dsadasdsadasfagfaga");
            foreach(var it in coll)
            {
                var rb = it.GetComponentInParent<Rigidbody2D>();
                if(rb)
                {
                    Vector2 toMe = rb.position - (Vector2)transform.position;
                    
                    //toMe /= Mathf.Clamp(toMe.sqrMagnitude, 0.001f, 1000000f);
                    rb.AddForce(toMe.normalized * explosionForce);
                }
            }
        }
    }
}
