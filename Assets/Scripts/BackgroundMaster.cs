using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMaster : MonoBehaviour
{
    public GameObject BG1, BG2, BG3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetLevelBackground(int l){
        BG1.SetActive(false);
        BG2.SetActive(false);
        BG3.SetActive(false);

        switch(l){
            case 1:
                BG1.SetActive(true);
                break;
            case 2:
                BG2.SetActive(true);
                break;
            case 3:
                BG3.SetActive(true);
                break;
        }
    }
}
