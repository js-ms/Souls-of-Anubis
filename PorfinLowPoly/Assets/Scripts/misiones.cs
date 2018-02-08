using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class misiones : MonoBehaviour {

	private int tiempoCamara;
	public GameObject text1;
	public GameObject text2;
	public GameObject text3;
	public GameObject text4;
	public GameObject dialogo1;
	private bool tuto;
	private bool entreOasis;

	// Use this for initialization
	void Start () {
		tiempoCamara = 0;
		tuto = true;
		GetComponent<CharacterController> ().enabled = false;
		entreOasis = false;
	}
	
	// Update is called once per frame
	void Update () {
		StartCoroutine (esperarAnimacion());
		moverCamera ();
		tiempoCamara++;

	}

	IEnumerator esperarAnimacion(){
		yield return new WaitForSeconds (7);
		GetComponent<CharacterController> ().enabled = true;
		if (tuto == true) {
			tuto = false;
			text1.SetActive (true);
			yield return new WaitForSeconds (2);
			text2.SetActive (true);
			yield return new WaitForSeconds (2);
			text2.SetActive (false);
			yield return new WaitForSeconds (2);
			text3.SetActive (true);
			yield return new WaitForSeconds (2);
			text3.SetActive (false);
			yield return new WaitForSeconds (2);
			text4.SetActive (true);
			yield return new WaitForSeconds (2);
			text4.SetActive (false);
		}

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

	void OnTriggerEnter(Collider collision){
		if (collision.name == "Waving") {
			if (!entreOasis) {
				StartCoroutine (misionOasis ());
			}
		}
	}

	IEnumerator misionOasis(){
		GameObject indicadorOasis=GameObject.Find ("indicador3DOasis");
		text1.SetActive (false);
		indicadorOasis.SetActive (false);
		dialogo1.SetActive (true);
		yield return new WaitForSeconds (3);
		dialogo1.SetActive (false);
		entreOasis = true;
	}
}