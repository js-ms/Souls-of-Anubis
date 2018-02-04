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
		if (!adentro) {
			if (colision.name == "Linkle") {
				this.text.SetActive (true);
				if (this.text2 != null) {
					this.text2.SetActive (true);
				}
				StartCoroutine (volverFalso ());
			}
			adentro = true;
		} else
			adentro = false;
	}

	IEnumerator volverFalso(){
		yield return new WaitForSeconds (2);
		this.text.SetActive (false);
		if (this.text2 != null) {
			this.text2.SetActive (false);
		}
	}
}
