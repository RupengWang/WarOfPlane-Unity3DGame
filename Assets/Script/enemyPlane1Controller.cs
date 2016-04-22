using UnityEngine;
using System.Collections;

public class enemyPlane1Controller : MonoBehaviour {
	public float speed = 13.0f;
	//public GameObject explodeHeroPlane_b1;
	public GameObject explodeHeroProjectile_b1;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (0,-Time.deltaTime*speed,0);
		if (transform.position.y < -35.0f) {
			//transform.position=new Vector3(Random.Range(-21,21),50,0);
			Destroy(gameObject);
		}
	}
	void OnTriggerEnter(Collider other){
		if (other.tag == "heroProjectile") {
			Instantiate (explodeHeroProjectile_b1, transform.position, transform.rotation);
			//transform.position=new Vector3(Random.Range(-21,21),50,0);
			planeController.score+=100;
			Destroy(other.gameObject);
			Destroy(gameObject);
		}
		//if (other.tag == "heroPlane") {
			//Instantiate (explodeHeroPlane_b1, transform.position, transform.rotation);
			//Destroy(gameObject);
		//}
	}
}
