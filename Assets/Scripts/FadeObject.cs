using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeObject : MonoBehaviour
{
    private bool fadeOut, fadeIn;
    public float fadeSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        if(Input.GetKeyDown(KeyCode.U)){
            StartCoroutine(FadeOutObject());
        }
        if(Input.GetKeyDown(KeyCode.I)){
            StartCoroutine(FadeInObject());
        }
    }

    public IEnumerator FadeOutObject(){
        Color objectColor = this.GetComponent<Renderer>().material.color;
        float fadeAmount = objectColor.a - (fadeSpeed * Time.deltaTime);

        objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
        this.GetComponent<Renderer>().material.color = objectColor;

        yield return null;
    }

    public IEnumerator FadeInObject(){
        Color objectColor = this.GetComponent<Renderer>().material.color;
        float fadeAmount = objectColor.a + (fadeSpeed * Time.deltaTime);

        objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
        this.GetComponent<Renderer>().material.color = objectColor;

        yield return null;
    }
}
