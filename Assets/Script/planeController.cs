using UnityEngine;
using System.Collections;

public class planeController : MonoBehaviour {
	public float speed = 10.0f;
	public GameObject projectile_b1;
	public GameObject enemyPlane1_b1;
	public GameObject enemyPlane2_b1;
	public GameObject enemyPlane3_b1;
	//时间控制器，控制子弹飞机的出现时间	
	private float myTime1 = 0;
	private float myTime2 = 0;
	private float myTime3 = 0; 
	private float myTime4 = 0;

	private Vector3 V1;
	private Vector3 V2;
	private Vector3 V3;

	public static int score = 0;
	// Use this for initialization
	void Start () {
		speed = 20.0f;
		score = 0;
	}
	//控制飞机的上下左右移动
	void Update () {
		var dir = Vector3.zero;
		dir.x = -Input.acceleration.y;
		dir.z = Input.acceleration.x;
		
		// clamp acceleration vector to the unit sphere
		if (dir.sqrMagnitude > 1)
			dir.Normalize();
		
		// Make it move 10 meters per second instead of 10 meters per frame...
		dir *= Time.deltaTime;
		
		// Move object
		transform.Translate (dir * speed);

		if(transform.position.x>=-21.0f&&transform.position.x<=21.0f&&transform.position.y>=-37.0f&&transform.position.y<=40.0f)
			transform.Translate(Input.GetAxis("Horizontal")*Time.deltaTime*speed,Input.GetAxis("Vertical")*Time.deltaTime*speed,0);
		if (transform.position.x > 21.0f)
			transform.position = new Vector3(20.9f,transform.position.y,transform.position.z);
		if (transform.position.x < -21.0f)
			transform.position = new Vector3(-20.9f,transform.position.y,transform.position.z);
		if (transform.position.y > 40.0f)
			transform.position = new Vector3(transform.position.x,39.9f,transform.position.z);
		if (transform.position.y < -37.0f)
			transform.position = new Vector3(transform.position.x,-36.9f,transform.position.z);
		myTime1 += Time.deltaTime;
		myTime2 += Time.deltaTime;
		myTime3 += Time.deltaTime;
		myTime4 += Time.deltaTime;
		if (myTime1 > 0.2f) {	
			Instantiate (projectile_b1, transform.position, transform.rotation);
			myTime1 = 0;
		}
		V1 = new Vector3 (Random.Range(-21,21),50,0);
		V2 = new Vector3 (Random.Range(-17,17),55,0);
		V3 = new Vector3 (Random.Range(-19,19),55,0);
		if(myTime2>0.6f){
			Instantiate(enemyPlane1_b1,V1,transform.rotation);
			myTime2 = 0;
		}
		if(myTime3>4.0f){
			Instantiate(enemyPlane2_b1,V2,transform.rotation);
			myTime3 = 0;
		}
		if(myTime4>2.0f){
			Instantiate(enemyPlane3_b1,V3,transform.rotation);
			myTime4 = 0;
		}
	}
	void OnTriggerEnter(Collider enemy){
		if (enemy.tag == "enemyPlane1") {
			Destroy(enemy.gameObject);
		}
	}
	void OnGUI(){
		GUI.Label (new Rect(250,10,120,20),"Your score : "+score.ToString());
	}
}
