using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class controllerGUI : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void jugar(){
		Scene scene = SceneManager.GetSceneByName ("ProPro");
		GameObject disp = GameObject.Find ("disparodef");
		SceneManager.LoadScene ("ProPro");
		SceneManager.MoveGameObjectToScene (disp,scene);
	}
}
