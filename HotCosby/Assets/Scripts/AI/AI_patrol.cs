﻿using UnityEngine;
using System.Collections;

public class AI_patrol : IAI_state {

	private controller_ai controller;
	private Vector3 curWaypoint;

	public AI_patrol(controller_ai c) {
		controller = c;
	}

	public void Start() {
		controller.curState = this;
		curWaypoint = controller.PatrolPoints [0].transform.position;
		controller.agent.destination = curWaypoint;
		Debug.Log ("staring patrol");
		Debug.Log ("Going to: " + curWaypoint.ToString());
	}

	public void Start(Vector3 target) {
		
	}

	public void UpdateState () {
		if (Vector3.Distance (controller.agent.destination, controller.transform.position) < 1.0) {
			GoToNextPost ();
		}
	}

	public void GoToNextPost() {
		controller.agent.destination = controller.PatrolPoints [Random.Range (0, controller.PatrolPoints.Count)].transform.position;
	}

	public void OnTriggerStay(Collider other) {
		if (other.CompareTag ("Player")) {
			Vector3 pos = controller.gameObject.transform.position;
			Ray ray = new Ray (pos, (other.transform.position - pos).normalized);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit)) {
				if (hit.collider.CompareTag ("Player"))
					controller.chaseState.Start (hit.transform.position);
			}
		}
	}

	public void OnTriggerExit(Collider other) {

	}
}
