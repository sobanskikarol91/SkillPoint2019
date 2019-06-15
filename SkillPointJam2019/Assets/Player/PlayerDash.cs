using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    public AudioClip clipSnd;


    public void PlayDash()
    {
        Debug.Log("sss");
        AudioSource.PlayClipAtPoint(clipSnd, transform.position);
    }
}
