using UnityEngine;
using System.Collections;

public class controller_player : MonoBehaviour {

	// Use this for initialization
	public float speed = 0;
	private int forward = 0;
	private int right = 0;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<Rigidbody> ().velocity = (new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical"))) * Time.deltaTime * speed;
	}
}
