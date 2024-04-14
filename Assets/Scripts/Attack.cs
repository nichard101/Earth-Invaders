using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public Transform shotPrefab;
    public float autoShootProbability;
    public float fireCooldownTime;
    float fireCooldownTimeLeft = 0;
    public bool willShoot;
    public AudioClip shotSound = null;

    void Update () {
      if(fireCooldownTimeLeft > 0) {
         fireCooldownTimeLeft -= Time.deltaTime;
      }
        float randomSample = Random.Range(0f, 1f);
        if (randomSample < autoShootProbability && willShoot)
        {           
            Shoot();
        }

    }

    public void Shoot() {
      if(fireCooldownTimeLeft <= 0) {
         Transform shot = Instantiate(shotPrefab);
         shot.position = transform.position;
         fireCooldownTimeLeft = fireCooldownTime; 
            if(shotSound != null) {
                AudioSource.PlayClipAtPoint(shotSound, transform.position);
            }
        }
    }
}
