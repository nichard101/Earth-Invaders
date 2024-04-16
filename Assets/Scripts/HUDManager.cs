using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//hi

public class HUDManager : MonoBehaviour {

   public GameObject hud;
   
   public Text hudScore = null;
   public Text hudHealth = null;
   
   // Use this for initialization
   void Start () {

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
}
