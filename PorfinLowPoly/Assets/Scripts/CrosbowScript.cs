using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosbowScript : MonoBehaviour {

	public GameObject BalaSource;
	GameObject BalaIzq;
	GameObject BalaDer;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		StartCoroutine (disparar ());
	}

	IEnumerator disparar(){
		if (Input.GetMouseButtonDown (0)) {
			yield return new WaitForSeconds (1);
			BalaDer = Instantiate (BalaSource, GameObject.Find ("shoot1").transform.position, GameObject.Find ("shoot1").transform.rotation) as GameObject;
			BalaIzq = Instantiate (BalaSource, GameObject.Find ("shoot2").transform.position, GameObject.Find ("shoot2").transform.rotation) as GameObject;
			BalaDer.GetComponent<Rigidbody> ().AddForce (GameObject.Find ("shoot1").transform.forward * 25000 * Time.deltaTime);
			BalaIzq.GetComponent<Rigidbody> ().AddForce (GameObject.Find ("shoot2").transform.forward * 25000 * Time.deltaTime);
		}
	}
}
