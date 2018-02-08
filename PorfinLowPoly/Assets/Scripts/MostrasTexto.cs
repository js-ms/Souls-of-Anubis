using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MostrasTexto : MonoBehaviour {
	public GameObject text;
	public GameObject text2;
	private bool adentro;
	// Use this for initialization
	void Start () {
		adentro = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider colision){
		print (adentro);
		if (adentro) {
			if (colision.name == "Linkle") {
				text.SetActive (true);
				if (text2 != null) {
					text2.SetActive (true);
				}
				StartCoroutine (volverFalso ());
			}
			adentro = false;
		} else
			adentro = true;
	}

	IEnumerator volverFalso(){
		yield return new WaitForSeconds (2);
		text.SetActive (false);
		if (text2 != null) {
			text2.SetActive (false);
		}
	}
}
