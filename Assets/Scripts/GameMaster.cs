using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{
    public static int playerHealth = 3;

    public static int playerScore = 0;

    public static int waveNum = 0;

    static PlayerSpawner spawner;

    void Start() {
        
    }

    public static void EnemyHit(Alien alien) {
        playerScore += alien.points;

        Transform enemyWave = alien.transform.parent;

        Component[] aliensLeft = enemyWave.GetComponentsInChildren<Alien>();

        if(aliensLeft.Length == 1) {
            waveNum++;
            if(waveNum==3){
                spawner.levelOver = true;
                waveNum=0;
            } else {
                EnemyWave wave = GameObject.Find("EnemyWave").GetComponent<EnemyWave>();
                wave.SpawnWave();
            }
        }
    }

    public static void PlayerHit(int damage) {
        spawner = GameObject.Find("PlayerSpawner").GetComponent<PlayerSpawner>();
        playerHealth-= damage;
        if(playerHealth<=0){
            spawner.Killed();
        }
    }
}
