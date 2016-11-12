using UnityEngine;
using System.Collections;

public interface IAI_state {

	void OnTriggerStay(Collider other);
	void UpdateState ();
	void Start ();
	void Start (Vector3 target);
}
