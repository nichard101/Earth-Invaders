using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerShot : MonoBehaviour
{
    public GameObject explosionPrefab;

    public void explosion() {
        GameObject explosion = Instantiate(explosionPrefab, this.transform.localPosition, Quaternion.identity);
        explosion.transform.localScale = 5 * explosion.transform.localScale;
    }
}
