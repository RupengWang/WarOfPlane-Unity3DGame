using UnityEngine;
using System.Collections;

public class enemyPlane2Controller : MonoBehaviour {
	public float speed = 9.0f;
	public int lives = 10;
	public GameObject explodeHeroProjectile_b1;
	// Use this for initialization
	void Start () {
		speed = 10.0f;
		lives = 15;
	}
	
	// Update is called once per frame
	void Update () {
			transform.Translate (0,-Time.deltaTime*speed,0);
			if (transform.position.y < -35.0f) {
				Destroy (gameObject);
			}
	}
	void OnTriggerEnter(Collider other){
		if (other.tag == "heroProjectile") {
			lives--;
			planeController.score+=100;
			Destroy(other.gameObject);
			if(lives <= 0){
				Instantiate (explodeHeroProjectile_b1, transform.position, transform.rotation);
				Destroy(other.gameObject);
				Destroy(gameObject);
			}
		}
	}
}
