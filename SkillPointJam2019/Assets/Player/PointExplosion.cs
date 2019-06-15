using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointExplosion : MonoBehaviour
{
    private void Start()
    {
        Invoke("Destroy", 0.5f);
    }

    void Destroy()
    {
        Destroy(this.gameObject);
    }
}
