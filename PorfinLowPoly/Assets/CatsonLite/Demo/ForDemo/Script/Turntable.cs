using UnityEngine;
using System.Collections;

public class Turntable : MonoBehaviour {

	public float turnSpeed;

	// Update is called once per frame
	void Update () {

		transform.Rotate (-Vector3.up * Time.deltaTime * turnSpeed, Space.Self);
	}
}
