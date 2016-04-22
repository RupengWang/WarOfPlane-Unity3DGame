using UnityEngine;
using System.Collections;

public class backgroundController : MonoBehaviour {	
	public float speed = 4.0f;
	// Use this for initialization
	void Start () {
		speed = 6.0f;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (0,-Time.deltaTime*speed,0);
		if (transform.position.y < -85.0f)
			transform.position =new Vector3(transform.position.x,85.0f,transform.position.z);
	}
}
