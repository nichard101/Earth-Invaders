using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{

    public AudioClip explosionSound = null;
    void Start()
    {
        Destroy(gameObject, 0.5f);
        if(explosionSound != null) {
            AudioSource.PlayClipAtPoint(explosionSound, transform.position);
        }
    }
}