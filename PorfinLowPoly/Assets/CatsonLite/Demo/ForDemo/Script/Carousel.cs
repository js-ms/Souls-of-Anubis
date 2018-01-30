/* Scripted by Bamabu @ Polydactyl */
using System.Collections;
using UnityEngine;

public class Carousel : MonoBehaviour {

	public float speed = 20;
	public Vector3 offset = new Vector3 (15, 0, 0);
	public Vector3 truePos;
	public int currentIndex = 0;

	private int childCount;

	void Start () {

		childCount = transform.childCount;
		truePos = transform.position;
	}

	public void Next () {
		
		if (currentIndex < childCount - 1)
		{
			currentIndex++;
			truePos += -offset;

			StopAllCoroutines ();
			StartCoroutine (Move ());
		}
	}

	public void Prev () {
		
		if (currentIndex > 0)
		{
			currentIndex--;
			truePos += offset;

			StopAllCoroutines ();
			StartCoroutine (Move ());
		}
	}

	public IEnumerator Move () {

		float timer = 0f;

		while (timer < 1f)
		{
			timer += Time.deltaTime;
			transform.position = Vector3.Lerp (transform.position, truePos, timer);

			yield return null;
		}
	}
}
