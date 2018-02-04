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

	public GameObject BalaSource;
	GameObject BalaIzq;
	GameObject BalaDer;

	// Use this for initialization
	void Start () {
		this.gravedad = 2.0f;
		this.movimiendoLinkle = Vector3.zero;
		this.cont = 0;
	}

	// Update is called once per frame
	void Update () {
		if (personaje.GetComponent<CharacterController> ().isGrounded) {
			if (Input.GetKey (KeyCode.W)) {
				GetComponent<Animator> ().SetBool ("isWalking", true);
				transform.Translate (Vector3.forward * moveSpeed * Time.deltaTime);

			}
			if (Input.GetKeyUp (KeyCode.W)) {
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
			if (Input.GetKey(KeyCode.Mouse0)) {
				GetComponent<Animator> ().SetBool ("isShooting", true);
			}
			if (Input.GetKeyUp(KeyCode.Mouse0)) {
				GetComponent<Animator> ().SetBool ("isShooting", false);
			}

			if (Input.GetKey (KeyCode.S)) {
				GetComponent<Animator> ().SetBool ("isRunning", false);
				GetComponent<Animator> ().SetBool ("isWalking", false);
				GetComponent<Animator> ().SetBool ("isBack", true);
				transform.Translate (-Vector3.forward * moveSpeed * Time.deltaTime);
			}

			if (Input.GetKeyUp(KeyCode.S))
				GetComponent<Animator> ().SetBool ("isBack", false);

			if (Input.GetKey (KeyCode.A))
				transform.Rotate (Vector3.up, -turnSpeed * Time.deltaTime);

			if (Input.GetKey (KeyCode.D))
				transform.Rotate (Vector3.up, turnSpeed * Time.deltaTime);
		
		}
		GetComponent<CharacterController>().Move(Vector3.down*10f*Time.deltaTime);
	}


	public void disparar(){
		print (GameObject.Find ("shoot1").transform.position);
		BalaDer = Instantiate (BalaSource, GameObject.Find ("shoot1").transform.position,GameObject.Find ("shoot1").transform.rotation) as GameObject;
		BalaIzq = Instantiate (BalaSource, GameObject.Find ("shoot2").transform.position,GameObject.Find ("shoot2").transform.rotation) as GameObject;
		BalaDer.GetComponent<Rigidbody> ().AddForce (GameObject.Find ("shoot1").transform.forward * 100000 * Time.deltaTime);
		BalaIzq.GetComponent<Rigidbody> ().AddForce (GameObject.Find ("shoot2").transform.forward * 100000 * Time.deltaTime);
	}
}
