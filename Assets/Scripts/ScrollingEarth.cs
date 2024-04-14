using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingEarth : MonoBehaviour
{
    public GameObject earthPrefab;

    public float vSpeed;

    GameObject earth;

    void Start(){
        earth = Instantiate(earthPrefab);
    }
    void Update()
    {
        MoveDown();
    }

    void MoveDown(){
        float move = Time.deltaTime * vSpeed;
        earth.transform.Translate(new Vector3(0,-move,0));
    }
}