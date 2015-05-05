using UnityEngine;
using System.Collections;

public class Needle : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space)) {
			StartCoroutine(TurnOn());
		}
	}

	IEnumerator TurnOn() {
		iTween.RotateBy(this.gameObject, iTween.Hash("y", -18.0f / 360,
													"time", 3.0f));

		GameObject.Find("Vinyl").GetComponent<VinylRotate>().StartRotating();

		yield return new WaitForSeconds(3);

		iTween.RotateBy(this.gameObject, iTween.Hash("x", -2.0f / 360,
													"time", 0.8f));

		yield return new WaitForSeconds(0.2f);

		this.GetComponent<AudioSource>().Play();
	}
}

