using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
   
   void Start(){
        
   }

   public void StartGame(){
      GameMaster.ResetGame();
      SceneManager.LoadScene("Level");
   }
}