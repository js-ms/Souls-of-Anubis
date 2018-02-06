using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ryos : MonoBehaviour {

	public RaycastHit Objetivo;
	public GameObject Enemigo;
	bool blocked;
	UnityEngine.AI.NavMeshAgent Agente;
	Vector3 Inicial;
	bool Musica;
	/* ______________________________________*/
	public int Vida;//vida del personaje
	/* ______________________________________*/

	// Use this for initialization
	void Start () {
		this.Inicial = this.gameObject.transform.position;
		this.blocked = false;
		this.Agente = this.GetComponent<UnityEngine.AI.NavMeshAgent> ();
		this.Vida = 1;//esta vivo
		this.Musica=true;
	}

	// Update is called once per frame
	void  Update()
	{  

		UnityEngine.AI.NavMeshHit hit;
		bool blocked = UnityEngine.AI.NavMesh.Raycast (this.transform.position, this.Enemigo.transform.position, out hit, UnityEngine.AI.NavMesh.AllAreas);
		Debug.DrawLine (this.transform.position, this.Enemigo.transform.position, blocked ? Color.green : Color.red);
		if ((hit.distance < 10f) && (!blocked)) {
			Seguir (this.Enemigo.transform.position);
			Correr ();
		} else {
			print (hit.distance);
			Seguir (this.Inicial);
			Idle ();
		}

	}

	public void Seguir(Vector3 Objetivo)
	{
		Objetivo=atacar (Objetivo);
		this.Agente.Warp (Objetivo);
		this.Agente.destination = Objetivo;


	}
	public void Idle()//regresa al punto inicial
	{   
		float distancia = Vector3.Distance (this.transform.position,this.Inicial);
		//llego al origen
		if (distancia < 1f) {
			this.transform.position = this.Inicial;
			GetComponent<Animator> ().SetInteger ("Estado", 1);
		}
	}
	public Vector3 atacar(Vector3 Objetivo)//ejecuta la animacion de atacar una distancia menor a 1.5
	{
		float distancia = Vector3.Distance (this.transform.position,this.Enemigo.transform.position);
		if (distancia <3f) {
			Objetivo = this.transform.position;
			GetComponent<Animator> ().SetInteger ("Atacar", 1);
//			ReproducirSonidos (GetComponents<AudioSource> ()[0]);//0 es el golpe
//			ReproducirSonidos (GetComponents<AudioSource> ()[1]);//1 es el grito

		}
		else GetComponent<Animator> ().SetInteger ("Atacar", 2);
		return(Objetivo);
	}

	public void Correr()//ejecuta la animacion de correr a una distancia mayor a 1.5
	{   float distancia = Vector3.Distance (this.transform.position,this.Enemigo.transform.position);
		if (distancia >= 1.5f) 
			GetComponent<Animator> ().SetInteger ("Estado", 2);

	}

	//cuando le pegan el tiro en la cabeza se elimina este objeto por consiguiente la programacion termina
	void OnTriggerEnter(Collider other) {
		//print (other.name);
		if (other.name == "disparodef(Clone)") {
			//print ("Entre");
			GetComponent<Animator> ().SetTrigger ("Headshoot");
			Destroy (this,0.15f);
			ReproducirSonidos (GetComponents<AudioSource> () [0]);
			ReproducirSonidos (GetComponents<AudioSource> () [1]);
		}
	}

	public void ReproducirSonidos(AudioSource Sonido)
	{
		if (!Sonido.isPlaying && this.Musica) {//si no se esta reproduciendo activa el sonido el vector en su campo 0 es para el golpe
			Sonido.Play ();
			this.Musica = false;
		} else
			Sonido.Stop ();
	}
}
