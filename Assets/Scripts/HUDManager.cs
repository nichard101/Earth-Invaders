using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//hi

public class HUDManager : MonoBehaviour {

   public GameObject HUD;
   public Animator transition;
   
   public Text hudScore = null;
   public Text hudHealth = null;
   public Text levelText = null;
   
   // Use this for initialization
   void Start () {
      levelText.text = "LEVEL " + GameMaster.currentLevel;
   }
   
   // Update is called once per frame
   void Update () {

      hudScore.text = "Score: " + GameMaster.playerScore;
      int healthNum = GameMaster.playerHealth;
      if(healthNum < 0){
         healthNum = 0;
      }
      hudHealth.text = "Health: " + healthNum;

      if(Input.GetKeyDown(KeyCode.Escape)) {
         // If user presses ESC, show the pause menu in pause mode

        //  if(!upgradeMenu.isActive){
        //     pauseMenu.ShowPause();
        //     GameMaster.StopTheCount();
        //     hud.SetActive(false);
        //     GameMaster.pause = true;
        //  }
    //   } else if(Input.GetKeyDown(KeyCode.Space)) {
    //      upgradeMenu.ShowMenu();
    //      GameMaster.StopTheCount();
    //      GameMaster.pause = true;
    //   }
        }
   }

   public void Pause(){

   }

   public void Unpause(){

   }

   public void StartOfLevel(){
      
   }

   public void EndOfLevel(){
      FadeToLevel();
   }

   // "Continue Level" HUD button function - loads next level
   public void NextLevel(){
      GameMaster.currentLevel += 1;
      transition.SetTrigger("FadeExit");
   }

   public void LoadLevel(){
      SceneManager.LoadScene("Level");
   }

   public static void BackToMenu(){

   }

   public void FadeToLevel(){
      HUD.SetActive(false);
      transition.SetTrigger("FadeOut");
   }

   public void OnFadeComplete(){
      //ContinueButton.SetActive(true);
   }

}
