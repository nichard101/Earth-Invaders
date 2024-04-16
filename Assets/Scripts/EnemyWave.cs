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

    public int alienNum = 0;

    public int level;

    int direction =-1;

    Vector3 OGPos;

    void Start()
    {
        OGPos = transform.localPosition;
        SpawnWave();
    }

    public void SpawnWave(){
        transform.localPosition = OGPos;
        int lines = 3;
        if(level==3){
            lines = 2;
        }

        if(alienNum==0){
            alienPrefab = alienPrefab1;
        } else if(alienNum == 1){
            alienPrefab = alienPrefab2;
        } else {
            alienPrefab = alienPrefab3;
        }

        int minEnemies;
        int maxEnemies;
        if(level==1){
            minEnemies = 3;
            maxEnemies = 3;
        } else if(level==2){
            minEnemies=3;
            maxEnemies=2;
        } else {
            minEnemies = 2;
            maxEnemies = 2;
        }
        for(int y = 0; y < 3; y++){ // repeat 3 times
            bool isEven = (y % 2 == 0);
            float offsetX = (isEven ? 0.0f : 0.5f) * gapHorizontal;
            for(int x = -minEnemies; x < maxEnemies; ++x) {
                Transform alien = Instantiate(alienPrefab); // creates an alien
                alien.parent = transform; //  
                alien.localPosition = new Vector3(
                    (x*gapHorizontal)+ offsetX,
                    0 + (y * gapVertical),
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
         transform.Translate(new Vector3(0,-gapVertical/2,0));
      }
   }

   public void Activate() {

   }

   public void Deactivate() {
       
   }
}
