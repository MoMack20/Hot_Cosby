﻿using UnityEngine;
using System.Collections;

public class MiniMap : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 playerPos = GameObject.FindGameObjectWithTag ("Player").transform.position;
		transform.position = new Vector3 (playerPos.x, 40, playerPos.z);
	}
}
