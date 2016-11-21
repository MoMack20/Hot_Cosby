using UnityEngine;
using System.Collections;

public class key_collector : MonoBehaviour {

	// Use this for initialization
	ArrayList mKeys;
	ArrayList keysOnMap;
	void Start () {
		mKeys = new ArrayList ();
		keysOnMap = new ArrayList (GameObject.FindGameObjectsWithTag ("Door Key"));
	}
	
	// Update is called once per frame
	void Update () {
		foreach (GameObject key in keysOnMap) {
			if (Vector3.Distance (key.transform.position, transform.position) < 0.8) {
				mKeys.Add (key);
				keysOnMap.Remove (key);
				key.SetActive (false);
				Debug.Log ("You got " + mKeys.Count.ToString() + " keys");
				break;
			}
		}
		if (Vector3.Distance (transform.position, GameObject.FindGameObjectWithTag ("Exit Door").transform.position) < 1.0) {
			if (mKeys.Count == 3)
				Debug.Log ("YAY YOU WON!!!");
			else
				Debug.Log("You need 3 keys to leave");
		}
	}
}
