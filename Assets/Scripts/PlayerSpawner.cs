using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSpawner : MonoBehaviour
{
    
    public GameObject playerPrefab;
    GameObject player;
    public float minY;

    public float vSpeed;

    float currentY;
    public bool levelOver = false;

    public static int currentLevel = 1;

    bool killed = false;

    System.DateTime killTime;

    void Start()
    {         
        Spawn();
    }
    void Update()
    {
        if(killed){
            if(System.DateTime.Now >= killTime.AddSeconds(2)){
                SceneManager.LoadScene("GameOver");
            }
        } else if(levelOver || currentY < minY){
            player.GetComponent<Player>().player = false;
            MoveUp();
        } else if(currentY >= minY && !player.GetComponent<Player>().player){
            player.GetComponent<Player>().player = true;
        }
        
        if(currentY >= 2f){
            setY(3f);
            currentLevel ++;
            SceneManager.LoadScene("LevelTransition");
        }
    }

    void Spawn(){
        player = Instantiate(playerPrefab);

        player.transform.parent = transform;

        player.transform.localPosition = new Vector3(0, 0, 0);
        currentY = -2;
    }

    public void Killed(){
        killTime = System.DateTime.Now;
        killed = true;
        Destroy(player.gameObject);
    }

    void MoveUp(){
        float move = Time.deltaTime * vSpeed;
        player.transform.Translate(new Vector3(0,move,0));
        currentY += move;
    }

    public void setY(float y){
        minY = y;
    }
}
