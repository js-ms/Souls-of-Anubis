using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class moverCamara : MonoBehaviour {
	int con;
	// Use this for initialization
	void Start () {
		 con = 0;
	}
	
	// Update is called once per frame
	void Update () {
		print (con);
		if (con < 2000) {
			moverme ();
		} else {
			string sceneName = PlayerPrefs.GetString ("ultimaEscena");
			print (sceneName);
			SceneManager.LoadScene (sceneName);
		}
		con++;
	}

	void moverme(){
		transform.Translate (Vector3.left  * Time.deltaTime);
		//transform.Rotate (Vector3.up  *-15f*Time.deltaTime);
		Transform target= GameObject.Find("Linkle").transform;
		transform.LookAt(target);
	}
}
