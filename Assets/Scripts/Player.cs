/*
	Created by: Lech Szymanski
				lechszym@cs.otago.ac.nz
				Oct 30, 2015			
*/

using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	// Private variables (not visible in the Inspector panel)
	// The speed of player movement
	public float speed = 5;
	
	bool atLeftWall = false;
	bool atRightWall = false;
	public bool player = false;
	public bool invincible = false;
	bool shield = false;
	bool rapidFire = false;
	bool powerFire = false;
	System.DateTime shieldTime;
	System.DateTime rapidFireTime;
	SpriteRenderer rend;
	System.DateTime currentTime;
	System.DateTime lastHitTime;

	float OGCooldown;
    public GameObject explosionPrefab;
    public GameObject shieldBubble;

	public Transform powerShotPrefab;
	public Transform originalShotPrefab;
	int attackNum = 0;
	Color color;
	Attack attack;

	GameObject bubble;

	void Start() {
		rend = GetComponent<SpriteRenderer>();
		attack = GetComponent<Attack>();
		color = rend.color;
	}
	void OnTriggerEnter2D(Collider2D other) {
		if(other.tag == "LeftWall") {
			atLeftWall = true;
		} else if(other.tag == "RightWall") {
			atRightWall = true;
		} else if(other.tag == "Pickup") {
			Pickup pickup = other.GetComponent<Pickup>();
			if(pickup.type=="Shield" && !shield){
				Shield();
			} else if(pickup.type=="Health" && GameMaster.playerHealth < 3){
				GameMaster.playerHealth++;
			} else if(pickup.type=="RapidFire") {
				RapidFire();
			} else if(pickup.type=="PowerShot") {
				PowerShot();
			}
			Destroy(other.gameObject);
		} else {
			Projectile projectile = other.GetComponent<Projectile>();
			if(projectile != null && projectile.enemyProjectile) {
				if(currentTime>=lastHitTime.AddSeconds(1)){
					Destroy(other.gameObject);
					if(!shield && !invincible && player){
						TakeDamage(projectile.damage);
					}
				}
			}
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if(other.tag == "LeftWall") {
			atLeftWall = false;
		} else if(other.tag == "RightWall") {
			atRightWall = false;
		}
	}

	void OnCollisionEnter2D(Collision2D other) {
		if(other.gameObject.tag == "Enemy") {
			if(!invincible){
				if(shield){
					Destroy(bubble.gameObject);
					shield = false;
				} else {
					GameMaster.PlayerHit(3);
					Destroy(gameObject);
					lastHitTime = System.DateTime.Now;
				}
			}
		}
	}
	

	// Update is called once per frame
	void Update () {
		currentTime = System.DateTime.Now;
		if(player){
			if(shield){
				if(currentTime >= shieldTime){
					shield = false;
				}
			}
			if(rapidFire){
				if(currentTime >= rapidFireTime){
					NormalFire();
				}
			}
			if(powerFire){
				if(attackNum > 1){
					NormalShot();
					attackNum=0;
				}
			}
			float movementInput = Input.GetAxis("Horizontal");

			if(atLeftWall && (movementInput < 0)) {
				movementInput = 0;
			}
			if(atRightWall && (movementInput > 0)) {
				movementInput = 0;
			}

			// Move the player object
			transform.Translate( new Vector3(Time.deltaTime * speed * movementInput,0,0), Space.World);	

			if(Input.GetButton("Jump")) {
				Attack attack = GetComponent<Attack>();
				attack.Shoot(); 
				if(powerFire){
					attackNum++;
				}
			}
		}
	}

	void Shield () {
		shieldTime = currentTime.AddSeconds(10);
		shield = true;
		bubble = Instantiate(shieldBubble);
		bubble.transform.parent = this.transform;
		bubble.transform.localPosition = new Vector3(0,0,0);
	}

	void RapidFire() {
		if(powerFire){
			NormalShot();
		}
		rapidFire = true;
		OGCooldown = attack.fireCooldownTime;
		attack.fireCooldownTime = 0.1f;
		rend.color = Color.yellow;
		rapidFireTime = currentTime.AddSeconds(3);
	}

	void NormalFire() {
		rapidFire = false;
		attack.fireCooldownTime = OGCooldown;
		rend.color = color;
	}
	public void TakeDamage(int damage)
	{
		if(damage > 0){
			// Tints the sprite red and fades back to the origin color after a delay of 1 second
			StartCoroutine(ColorChangeSequence(rend, Color.red, 0.5f, 0));
			Instantiate(explosionPrefab, transform.position, Quaternion.identity);
			GameMaster.PlayerHit(damage);
			lastHitTime = System.DateTime.Now;
		}
	}

	void PowerShot() {
		if(rapidFire){
			NormalFire();
		}
		color = rend.color;
		rend.color = Color.magenta;
		originalShotPrefab = attack.shotPrefab;
		attack.shotPrefab = powerShotPrefab;
		powerFire = true;
	}

	void NormalShot() {
		rend.color = color;
		attack.shotPrefab = originalShotPrefab;
		powerFire = false;
	}

	IEnumerator ColorChangeSequence(SpriteRenderer sr, Color dmgColor, float duration, float delay)
	{
		// save origin color
		Color originColor = sr.color;

		// tint the sprite with damage color
		sr.color = dmgColor;

		// you can delay the animation
		yield return new WaitForSeconds(delay);

		// lerp animation with given duration in seconds
		for (float t = 0; t < 1.0f; t += Time.deltaTime/duration)
		{
			sr.color = Color.Lerp(dmgColor, originColor , t);

			yield return null;
		}

		// restore origin color
		sr.color = originColor;
	}

	public void ToggleInvisible(){
		rend.enabled ^= false;
	}
}