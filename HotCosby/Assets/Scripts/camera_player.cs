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
		transform.LookAt (target);
	}
}
