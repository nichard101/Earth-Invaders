using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
   
   System.DateTime currentTime;
   void Start(){
        currentTime = System.DateTime.Now;
   }

   void Update () {
      if(Input.GetKeyDown(KeyCode.Return)) {
         GameMaster.playerHealth = 3;
         GameMaster.playerScore = 0;
         PlayerSpawner.currentLevel = 1;
         
         SceneManager.LoadScene("LevelTransition");            
      }
   }


   void OnGUI() {
      GUI.color = Color.white;   
      GUI.skin.label.alignment = TextAnchor.MiddleCenter;
      GUI.skin.label.fontSize = 40;
      GUI.skin.label.fontStyle = FontStyle.Bold;
      GUI.Label(new Rect(0,0,Screen.width,Screen.height), "Press Enter to start");
   }
}