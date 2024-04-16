using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupSpawner : MonoBehaviour
{
    string[] pickupArray = {"Shield","Health","RapidFire","PowerFire"};
    public float shieldChance;
    public float healthChance;
    public float rapidfireChance;
    public float powerfireChance;
    float[] chances = new float[4];

    public GameObject shield;
    public GameObject health;
    public GameObject rapidFire;
    public GameObject powerFire;

    public float dropChance;


    void Start() {
        float randomSample = Random.Range(0f, 1f);
        chances[0] = healthChance;
        chances[1] = shieldChance;
        chances[2] = rapidfireChance;
        chances[3] = powerfireChance;
        if (randomSample < dropChance) {
            DropPickup();
        }
        Destroy(gameObject);
    }

    void DropPickup(){
        int pickupNum = 0;
        float temp = 0f;
        float rand = Random.Range(0f,1f);
        for(int i = 0; i < chances.Length; i++){
            temp += chances[i];
            if(rand <= temp){
                pickupNum = i+1;
                break;
            }
        }
        GameObject drop;
        if(pickupNum==1){
            drop = Instantiate(shield);
        } else if(pickupNum==2){
            drop = Instantiate(health);
        } else if(pickupNum==3){
            drop = Instantiate(rapidFire);
        } else if(pickupNum==4){
            drop = Instantiate(powerFire);
        } else {
            drop = null;
        }
        if(drop != null){
            drop.transform.position = this.transform.position;
        }
    }


}
