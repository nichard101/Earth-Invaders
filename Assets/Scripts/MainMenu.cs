using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {
   
   public Animator transition;
   void Start(){
        
   }

   public void StartGame(){
      GameMaster.ResetGame();
      SceneManager.LoadScene("Level");
   }

   public void GoCredits(){
      transition.ResetTrigger("MoveToMenu");
      transition.SetTrigger("MoveToCredits");
   }

   public void GoMenu(){
      transition.ResetTrigger("MoveToCredits");
      transition.SetTrigger("MoveToMenu");
   }

   public void QuitGame(){
      Application.Quit();
   }
}