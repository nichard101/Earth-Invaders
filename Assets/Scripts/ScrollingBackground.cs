using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    public float speed = 10f;

    [SerializeField]
    private Renderer bgRenderer = null;

    // Update is called once per frame
    void Update()
    {
        bgRenderer.material.mainTextureOffset += new Vector2(0,speed * Time.deltaTime);
    }
}
