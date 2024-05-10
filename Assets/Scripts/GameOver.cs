using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

    System.DateTime currentTime;
    public Text score, gameTime, title;

    float timeElapsed;

    void Start(){
        if(GameMaster.playerDead){
            title.text = "YOU DIED";
            title.color = Color.red;
        }
        timeElapsed = Time.time - GameMaster.gameTime;
        score.text = "Score: " + GameMaster.playerScore;
        gameTime.text = "Time: " + timeElapsed;
    }

    public void ReturnToMenu(){
        SceneManager.LoadScene("MainMenu");
    }
}