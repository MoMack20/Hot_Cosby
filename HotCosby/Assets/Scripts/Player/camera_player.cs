using UnityEngine;
using System.Collections;

public class camera_player : MonoBehaviour {

	private Transform target;
	// Use this for initialization
	void Start () {
		target = transform.parent;
	}

	// Update is called once per frame
	void Update () {
		//transform.RotateAround(target.transform.position, new Vector3(1,0,0), Input.GetAxis("Mouse Y") * 10);
		transform.LookAt (target);
	}
}
