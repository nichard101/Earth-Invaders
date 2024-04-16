using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransition : MonoBehaviour
{   
    System.DateTime currentTime;

    void Start(){
        currentTime = System.DateTime.Now;
    }
    void Update()
    {   
        if(Input.GetKeyDown(KeyCode.Return)) {
            GameMaster.playerHealth=3;
            SceneManager.LoadScene("Level");
      }
    }
    void OnGUI() {
      GUI.color = Color.white;   
      GUI.skin.label.alignment = TextAnchor.MiddleCenter;
      GUI.skin.label.fontSize = 40;
      GUI.skin.label.fontStyle = FontStyle.Bold;

      GUI.Label(new Rect(0,0,Screen.width,Screen.height), "LEVEL " + GameMaster.currentLevel);
   }
}
