using UnityEngine;
using System.Collections;

public class controller_player : MonoBehaviour {

	// Use this for initialization
	[Range(100,500)]
	public float speed = 0;
	private bool canRotate = false;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (1)) {
			canRotate = true;
			Cursor.lockState = CursorLockMode.Locked;
		}
		if(Input.GetMouseButtonUp(1)) {
			canRotate = false;
			Cursor.lockState = CursorLockMode.None;
		}
		if(canRotate)
			transform.Rotate (new Vector3 (0, Input.GetAxis ("Mouse X") * 100 * Time.deltaTime));
		GetComponent<Rigidbody> ().velocity = ((Input.GetAxis ("Vertical") * transform.forward)  + Input.GetAxis ("Horizontal") * transform.right) * speed * Time.deltaTime;
	}
}
