using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class misiones : MonoBehaviour {

	private int tiempoCamara;
	public GameObject text1;

	// Use this for initialization
	void Start () {
		tiempoCamara = 0;
		GetComponent<CharacterController> ().enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		StartCoroutine (esperarAnimacion());
		moverCamera ();
		tiempoCamara++;

	}

	IEnumerator esperarAnimacion(){
		yield return new WaitForSeconds (5);
		GetComponent<CharacterController> ().enabled = true;
		text1.SetActive (true);
	}

	void moverCamera(){
		GameObject camara = GameObject.Find ("VistaLinkle3ra");
		if (tiempoCamara < 100) {
			camara.transform.Rotate (Vector3.up * 20f * Time.deltaTime);
		}
		else if (tiempoCamara < 201) {
			camara.transform.Rotate (-Vector3.up * 20f * Time.deltaTime);
		}
		else if (tiempoCamara < 302) {
			camara.transform.Rotate (-Vector3.up * 20f * Time.deltaTime);
		}
		else if (tiempoCamara < 403) {
			camara.transform.Rotate (Vector3.up * 20f * Time.deltaTime);
		}
	}
}