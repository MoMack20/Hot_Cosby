using UnityEngine;
using System.Collections;

public class AI_idle : IAI_state {

	private controller_ai controller;
	private Vector3 initialForward;
	private bool leftFirst;
	private bool lookedLeft;
	private bool lookedRight;

	public AI_idle(controller_ai c) {
		controller = c;
	}

	public void Start() {
		controller.curState = this;
		initialForward = controller.GetComponent<Transform> ().forward;
		leftFirst = true;
		lookedLeft = false;
		lookedRight = false;
	}

	public void Start(Vector3 target) {
		controller.curState = this;
		Transform transform = controller.GetComponent<Transform> ();
		initialForward = transform.forward;
		lookedLeft = false;
		lookedRight = false;
		if (Vector3.Dot (initialForward, (transform.position + target).normalized) <= 0)
			leftFirst = true;
		else
			leftFirst = false;
	}

	public void UpdateState () {
		if (leftFirst) {
			if (!lookedLeft) {
				if (Vector3.Angle (controller.GetComponent<Transform> ().forward, initialForward) < 90) {
					controller.GetComponent<Transform> ().Rotate (Vector3.up, Time.deltaTime * -300);
				} else {
					lookedLeft = true;
					initialForward = controller.GetComponent<Transform> ().forward;
				}
			}
			if (lookedLeft && !lookedRight) {
				if (Vector3.Angle (controller.GetComponent<Transform> ().forward, initialForward) < 175) {
					controller.GetComponent<Transform> ().Rotate (Vector3.up, Time.deltaTime * 300);
				} else {
					lookedRight = true;
				}
			}
		} 
		if(!leftFirst){
			Debug.Log ("Right first");
			if (!lookedRight) {
				if (Vector3.Angle (controller.GetComponent<Transform> ().forward, initialForward) < 90) {
					controller.GetComponent<Transform> ().Rotate (Vector3.up, Time.deltaTime * 300);
				} else {
					lookedRight = true;
					initialForward = controller.GetComponent<Transform> ().forward;
				}
			}
			if (lookedRight && !lookedLeft) {
				if (Vector3.Angle (controller.GetComponent<Transform> ().forward, initialForward) < 175) {
					controller.GetComponent<Transform> ().Rotate (Vector3.up, Time.deltaTime * -300);
				} else {
					lookedLeft = true;
				}
			}
		}
		if (lookedLeft && lookedRight)
			controller.patrolState.Start ();
	}

	public void OnTriggerStay(Collider other) {
		if (other.CompareTag ("Player")) {
			Vector3 pos = controller.gameObject.transform.position;
			Ray ray = new Ray (pos, (other.transform.position - pos).normalized);
			RaycastHit hit;
			if (Physics.Raycast (ray, out hit)) {
				if (hit.collider.CompareTag ("Player")) {
					controller.chaseState.Start (hit.transform.position);
				}
			}
		}
	}

	public void OnTriggerExit(Collider other) {
		
	}
}