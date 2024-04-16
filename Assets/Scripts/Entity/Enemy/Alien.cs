using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour {

   public int points = 100;

   public GameObject explosionPrefab;
   public GameObject explosionPrefabBig;
	SpriteRenderer rend;

   public GameObject pickupSpawner;

   public int health = 1;

   Color colorOG;

   void Start() {
      rend = GetComponent<SpriteRenderer>();
      colorOG = rend.color;
   }
   void OnTriggerEnter2D(Collider2D other) {
      EnemyWave wave;
      if(other.tag == "LeftWall") {
         wave = transform.parent.GetComponent<EnemyWave>();
         wave.SetDirectionRight();
      } else if(other.tag == "RightWall") {
         wave = transform.parent.GetComponent<EnemyWave>();
         wave.SetDirectionLeft();
      } else {
         Projectile projectile = other.GetComponent<Projectile>();

         if(projectile != null && !projectile.enemyProjectile && !projectile.isPickup) {
            health-=projectile.damage;
            Destroy(other.gameObject);
            Vector3 pos = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1);
            StartCoroutine(ColorChangeSequence(rend, Color.red, 0.5f, 0));
            Instantiate(explosionPrefab, pos, Quaternion.identity);
            if(other.tag == "PowerShot"){
               Instantiate(explosionPrefabBig, pos, Quaternion.identity);
            }
            if(health <= 0){
               GameMaster.EnemyHit(this);
               GameObject pSpawn = Instantiate(pickupSpawner);
               pSpawn.transform.localPosition = pos;
               Destroy(gameObject);
            }
         }
      }
   }

   IEnumerator ColorChangeSequence(SpriteRenderer sr, Color dmgColor, float duration, float delay)
	{

		// tint the sprite with damage color
		sr.color = dmgColor;

		// you can delay the animation
		yield return new WaitForSeconds(delay);

		// lerp animation with given duration in seconds
		for (float t = 0; t < 1.0f; t += Time.deltaTime/duration)
		{
			sr.color = Color.Lerp(dmgColor, colorOG , t);

			yield return null;
		}

		// restore origin color
		sr.color = colorOG;
	}
}