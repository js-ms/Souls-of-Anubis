using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverLinkle : MonoBehaviour {

	private float gravedad;
	private Vector3 movimiendoLinkle; 
	public GameObject personaje;
	private float cont;

	public float moveSpeed = 10f;
	public float turnSpeed = 50f;

	// Use this for initialization
	void Start () {
		this.gravedad = 2.0f;
		this.movimiendoLinkle = Vector3.zero;
		this.cont = 0;
	}

	// Update is called once per frame
	void Update () {
		if (personaje.GetComponent<CharacterController> ().isGrounded) {
			print ("toque suelo");
			if (Input.GetKey (KeyCode.UpArrow)) {
				GetComponent<Animator> ().SetBool ("isWalking", true);
				transform.Translate (Vector3.forward * moveSpeed * Time.deltaTime);

			}
			if (Input.GetKeyUp (KeyCode.UpArrow)) {
				GetComponent<Animator> ().SetBool ("isRunning", false);
				GetComponent<Animator> ().SetBool ("isWalking", false);
				//transform.Translate (Vector3.forward * moveSpeed * Time.deltaTime);

			}
			if (Input.GetKey (KeyCode.LeftShift)) {
				GetComponent<Animator> ().SetBool ("isRunning", true);
				transform.TransformDirection (Vector3.forward * 2 * moveSpeed * Time.deltaTime);

			}
			if (Input.GetKeyUp (KeyCode.LeftShift)) {
				GetComponent<Animator> ().SetBool ("isRunning", false);
				GetComponent<Animator> ().SetBool ("isWalking", true);
				//transform.Translate (Vector3.forward * 2*moveSpeed * Time.deltaTime);

			}
			if (Input.GetKey (KeyCode.DownArrow)) {
				GetComponent<Animator> ().SetBool ("isRunning", false);
				GetComponent<Animator> ().SetBool ("isWalking", false);
				GetComponent<Animator> ().SetBool ("isBack", true);
				transform.Translate (-Vector3.forward * moveSpeed * Time.deltaTime);
			}
			if (Input.GetKeyUp(KeyCode.DownArrow)) {
				GetComponent<Animator> ().SetBool ("isBack", false);
			}

			if (Input.GetKeyDown (KeyCode.Mouse0)) {
				GetComponent<Animator> ().SetBool ("isShooting", true);
			}
			if (Input.GetKeyUp(KeyCode.Mouse0)) {
				GetComponent<Animator> ().SetBool ("isShooting", false);
			}

			if (Input.GetKey (KeyCode.LeftArrow))
				transform.Rotate (Vector3.up, -turnSpeed * Time.deltaTime);

			if (Input.GetKey (KeyCode.RightArrow))
				transform.Rotate (Vector3.up, turnSpeed * Time.deltaTime);
		
		}
		GetComponent<CharacterController>().Move(Vector3.down*Time.deltaTime);
	}
}
