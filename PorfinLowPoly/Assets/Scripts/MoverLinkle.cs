using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverLinkle : MonoBehaviour {

	private float gravedad;
	private Vector3 movimiendoLinkle; 
	public GameObject personaje;
	private float cont;

	// Use this for initialization
	void Start () {
		this.gravedad = 2.0f;
		this.movimiendoLinkle = Vector3.zero;
		this.cont = 0;
	}

	// Update is called once per frame
	void Update () {
		if (personaje.GetComponent<CharacterController> ().isGrounded) {
			if (Input.GetKeyDown (KeyCode.W)) {
				personaje.GetComponent<Animator> ().SetBool ("isWalking", true);
				movimiendoLinkle = personaje.transform.TransformDirection (Vector3.forward * 0.2f);
				movimiendoLinkle *= 12.0f;
			} else if (Input.GetKeyUp (KeyCode.W)) {
				movimiendoLinkle *= 0;
				personaje.GetComponent<Animator> ().SetBool ("isWalking", false);
			} else if (Input.GetKey (KeyCode.D)) {
				personaje.GetComponent<Animator> ().SetBool ("isWalking", false);
				cont += 2f;
				personaje.transform.Rotate (0, cont, 0);
				movimiendoLinkle *= 0;
				cont = 0;
			} else if (Input.GetKeyUp (KeyCode.D)) {
				cont = 0;
				movimiendoLinkle *= 0;
			} else if (Input.GetKey (KeyCode.A)) {
				personaje.GetComponent<Animator> ().SetBool ("isWalking", false);
				cont -= 2f;
				personaje.transform.Rotate (0, cont, 0);
				movimiendoLinkle *= 0;
				cont = 0;
			} else if (Input.GetKeyDown (KeyCode.A)) {
				cont = 0;
				movimiendoLinkle *= 0;
			} else if (Input.GetKeyDown (KeyCode.S)) {
				for (int i = 0; i < 45; i++) {
					int j = 4;
					personaje.transform.Rotate (0, j, 0);
					j += 4;
				}
				movimiendoLinkle *= 0;
			} else if (Input.GetKeyDown (KeyCode.LeftShift)) {
				personaje.GetComponent<Animator> ().SetBool ("isRunning", true);
				movimiendoLinkle = personaje.transform.TransformDirection (Vector3.forward * 0.4f);
				movimiendoLinkle *= 12.0f;
			} else if (Input.GetKeyUp (KeyCode.LeftShift)) {
				personaje.GetComponent<Animator> ().SetBool ("isRunning", false);
				movimiendoLinkle *= 0;
			}

			}

		if(!this.GetComponent<CharacterController> ().isGrounded){
			movimiendoLinkle.y -= gravedad * Time.deltaTime;
		}
		personaje.GetComponent<CharacterController>().Move(movimiendoLinkle*Time.deltaTime);
	}
}
