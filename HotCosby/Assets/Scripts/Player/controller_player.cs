using UnityEngine;
using System.Collections;

public class controller_player : MonoBehaviour {

	// Use this for initialization
	public float speed = 0;
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetMouseButton (1)) {
			transform.Rotate (new Vector3 (0, Input.GetAxis ("Mouse X") * 100 * Time.deltaTime));
		}
		GetComponent<Rigidbody> ().velocity = ((Input.GetAxis ("Vertical") * transform.forward)  + Input.GetAxis ("Horizontal") * transform.right) * speed;
	}
}
