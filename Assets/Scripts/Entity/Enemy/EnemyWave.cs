using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWave : MonoBehaviour
{
    
    public Transform alienPrefab1;
    public Transform alienPrefab2;
    public Transform alienPrefab3;
    Transform alienPrefab;
    public float speed;
    public float gapHorizontal = 0.25f;
    public float gapVertical = 0.25f;
    int level;
    int direction =-1;
    Vector3 OGPos;

    Vector3 alienSize;

    void Start()
    {
        
        level = GameMaster.currentLevel;
        OGPos = transform.localPosition;
        SpawnWave();
    }

    public void SpawnWave(){
        transform.localPosition = OGPos;
        int lines = 3;
        if(level==3){
            lines = 2;
        }

        int minEnemies;
        int maxEnemies;
        if(level==1){
            alienPrefab = alienPrefab1;
            minEnemies = 3;
            maxEnemies = 3;
        } else if(level==2){
            alienPrefab = alienPrefab2;
            minEnemies=3;
            maxEnemies=2;
        } else {
            alienPrefab = alienPrefab3;
            minEnemies = 3;
            maxEnemies = 2;
        }
        alienSize = alienPrefab.GetComponent<SpriteRenderer>().bounds.size;
        for(int y = 0; y < lines; y++){ // repeat 3 times
            bool isEven = (y % 2 == 0);
            float offsetX = (isEven ? 0.0f : 0.5f * gapHorizontal * alienSize.x);
            for(int x = -minEnemies; x < maxEnemies; ++x) {
                Transform alien = Instantiate(alienPrefab); // creates an alien
                alien.parent = transform; //  
                alien.localPosition = new Vector3(
                    (x * alienSize.x * gapHorizontal)+ offsetX,
                    0 + (y * (alienSize.y / 2) * gapVertical),
                    0
                );
            }
        }
    }

    // Update is called once per frame
    void Update()
    {   
        transform.Translate( new Vector3(Time.deltaTime * direction * speed,0,0));
    }

    // Method for changing wave direction (to be invoked
   // from a collider)
   public void SetDirectionLeft() {
      // Check if the current direction is to the right
      if(direction == 1) {
         // Changing the direction
         // push the wave down a bit as well
         direction = -1;   
         transform.Translate(new Vector3(0,-0.2f,0));
      }
   }
   
   // Method for changing wave direction (to be invoked
   // from a collider)
   public void SetDirectionRight() {
      // Check if the current direction is to the left
      if(direction == -1) {
         // Changing the direction
         // push the wave down a bit as well
         direction = 1;   
         transform.Translate(new Vector3(0,-(gapVertical/2) * alienSize.y/2,0));
      }
   }

   public void Activate() {

   }

   public void Deactivate() {
       
   }
}
