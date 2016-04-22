using UnityEngine;
using System.Collections;

public class heroProjectileController : MonoBehaviour {
	public float speed = 20.0f;	
	// Use this for initialization
	void Start () {
		speed = 50.0f;
	}
	// Update is called once per frame
	void Update () {
		transform.Translate (0,Time.deltaTime*speed,0);
		if (transform.position.y > 48.0f)
			Destroy (gameObject);
	}
}
