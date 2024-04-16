using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

    System.DateTime currentTime;

    void Start(){
        currentTime = System.DateTime.Now;
    }

    void Update() {
        if(Input.GetKeyDown(KeyCode.Return)) {    
            PlayerController.currentLevel = 1;
            SceneManager.LoadScene("MainMenu");
        }
    }

   // Display game over message
   void OnGUI() {
      
      // Show player score in white on the top left of the screen
      GUI.color = Color.white;   
      GUI.skin.label.alignment = TextAnchor.MiddleCenter;
      GUI.skin.label.fontSize = 40;
      GUI.skin.label.fontStyle = FontStyle.Bold;
      GUI.Label(new Rect(0,Screen.height/ 4f,Screen.width,70), "Game over");

      string message;

      if(GameMaster.playerHealth <= 0) {
          message = "You lost :(";
          GUI.color = Color.red;
      } else {
          message = "You won!!!";
          GUI.color = Color.white;
      }
      GUI.Label(new Rect(0,Screen.height/4f + 80f,Screen.width,70), message);

      GUI.color = Color.white;
      GUI.Label(new Rect(0,Screen.height/ 4f + 240f,Screen.width,70), "Press Enter to continue...");
   }
}