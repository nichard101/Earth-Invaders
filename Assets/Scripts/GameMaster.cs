using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{
    public static int playerHealth = 3;

    public static int playerScore = 0;
    public static int currentLevel = 1;

    public static int waveNum = 0;

    static PlayerController controller;

    void Start() {
        
    }

    public static void EnemyHit(Alien alien) {
        playerScore += alien.points;

        Transform enemyWave = alien.transform.parent;

        Component[] aliensLeft = enemyWave.GetComponentsInChildren<Alien>();

        if(aliensLeft.Length == 1) {
            waveNum++;
            if(waveNum==3){
                Player pl = GameObject.Find("Player").GetComponent<Player>();
                pl.levelOver = true;
                waveNum=0;
            } else {
                EnemyWave wave = GameObject.Find("EnemyWave").GetComponent<EnemyWave>();
                wave.SpawnWave();
            }
        }
    }

    public static void PlayerHit(int damage) {
        controller = GameObject.Find("PlayerController").GetComponent<PlayerController>();
        playerHealth-= damage;
        if(playerHealth<=0){
            controller.Killed();
        }
    }
}
