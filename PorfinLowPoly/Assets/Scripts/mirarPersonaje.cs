using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mirarPersonaje : MonoBehaviour {

	private GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.Find ("Linkle");
	}

	// Update is called once per frame
	void Update () {
		transform.Rotate (Vector3.left * 20f * Time.deltaTime);
	}
}