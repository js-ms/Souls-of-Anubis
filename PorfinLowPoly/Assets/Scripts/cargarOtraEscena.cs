using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;


public class cargarOtraEscena : MonoBehaviour {

	// Use this for initialization
	void Start () {
		string json = PlayerPrefs.GetString ("json");
		print (json);
		if (true) {
			//GameObject.Find ("escenaGameObject").SetActive (false);
			GameObject aux = GameObject.Find ("Linkle");
			//JsonUtility.FromJsonOverwrite (json, aux);
		}
	}
		

	void OnTriggerEnter(Collider colision){
		//Destroy (this);
		GameObject aux = GameObject.Find ("Linkle");
		kson linkle = new kson ();
		linkle.posicionPlayer = aux.transform;
		linkle.scene = SceneManager.GetActiveScene ().name ;
		string json = JsonUtility.ToJson (linkle);
		PlayerPrefs.SetString ("anterior", json);
		PlayerPrefs.SetString ("ultimaEscena", linkle.scene);
		print (json);
		print (PlayerPrefs.GetString("ultimaEscena"));
		SceneManager.LoadSceneAsync ("mainmenubienetselente");
	}
}
