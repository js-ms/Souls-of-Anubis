using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public GameObject player;
	public int moveSpeed;
	public int distHit;
	public int distSpawn;
	public int distWalk;

	// Use this for initialization
	void Start () {
		transform.localScale = new Vector3 (0, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
		float distance = Vector3.Distance (transform.position, player.transform.position);
		if (GetComponent<CharacterController> ().isGrounded) {
			if (distance<=distSpawn) {
				transform.LookAt (player.transform);
				GetComponent<Animator> ().SetBool ("isVisible", true);
				transform.localScale = new Vector3 (2, 2, 2);
			}
		} else {
			GetComponent<CharacterController>().Move(Vector3.down*20f*Time.deltaTime);
		}
	}
}
