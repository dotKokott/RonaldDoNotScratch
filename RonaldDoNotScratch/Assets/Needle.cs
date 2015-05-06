using UnityEngine;
using System.Collections;

public class Needle : MonoBehaviour {

	public int Lane = 0;
	public bool Playing;

	public bool Moving = false;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (!Playing && Input.GetKeyDown(KeyCode.Space)) {
			StartCoroutine(TurnOn());
		}

		if (!Playing) return;

		if (!Moving && Input.GetKeyDown(KeyCode.LeftArrow)) {
			StartCoroutine(Move(-1));
		}

		if (!Moving && Input.GetKeyDown(KeyCode.RightArrow)) {
			StartCoroutine(Move(1));
		}
	}	

	IEnumerator Move(int direction) {
		Moving = true;

		iTween.RotateBy(this.gameObject, iTween.Hash("x", 2.0f / 360,
													"time", 0.2f));

		yield return new WaitForSeconds(0.2f);

		iTween.RotateBy(this.gameObject, iTween.Hash("y", (8.0f * direction) / 360,
													"time", 0.8f));

		yield return new WaitForSeconds(0.8f);

		iTween.RotateBy(this.gameObject, iTween.Hash("x", -2.0f / 360,
													"time", 0.2f));

		yield return new WaitForSeconds(0.2f);

		Moving = false;
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

		Playing = true;
	}
}

