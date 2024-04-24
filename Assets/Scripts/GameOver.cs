using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {

    System.DateTime currentTime;
    public Text score, gameTime;

    float timeElapsed;

    void Start(){
        timeElapsed = Time.time - GameMaster.gameTime;
        score.text = "Score: " + GameMaster.playerScore;
        gameTime.text = "Time: " + timeElapsed;
    }

    public void ReturnToMenu(){
        SceneManager.LoadScene("MainMenu");
    }
}