using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public GameObject player;
    public float minY = -75;
    public float vSpeed;
    public bool levelOver = false;
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
        } else if(player.transform.position.y > Camera.main.ScreenToWorldPoint(new Vector2(0f, Camera.main.pixelHeight*1.2f)).y){
            GameMaster.currentLevel += 1;
            SceneManager.LoadScene("LevelTransition");
        } else if(player.GetComponent<Player>().levelOver || player.transform.position.y < minY){
            player.GetComponent<Player>().player = false;
            MoveUp();
        } else {
            player.GetComponent<Player>().player = true;
        }
    }

    void Spawn(){
        //player = GameObject.Find("Player");
        player.transform.parent = transform;

        //player.transform.localPosition = new Vector3(0, 0, 0);
        //currentY = -2;
    }

    public void Killed(){
        killTime = System.DateTime.Now;
        killed = true;
        Destroy(player.gameObject);
    }

    void MoveUp(){
        float move = Time.deltaTime * vSpeed;
        if(player.GetComponent<Player>().levelOver){
            move *= 2f;
        }
        player.transform.Translate(new Vector3(0,move,0));
    }

    public void setY(float y){
        minY = y;
    }
}
