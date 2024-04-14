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
            if(PlayerSpawner.currentLevel == 1){
                SceneManager.LoadScene("Level1");
            } else if(PlayerSpawner.currentLevel == 2){
                SceneManager.LoadScene("Level2");
            } else if(PlayerSpawner.currentLevel == 3){
                SceneManager.LoadScene("Level3");    
            }        
      }
    }
    void OnGUI() {
      GUI.color = Color.white;   
      GUI.skin.label.alignment = TextAnchor.MiddleCenter;
      GUI.skin.label.fontSize = 40;
      GUI.skin.label.fontStyle = FontStyle.Bold;

      GUI.Label(new Rect(0,0,Screen.width,Screen.height), "LEVEL " + PlayerSpawner.currentLevel);
   }
}
