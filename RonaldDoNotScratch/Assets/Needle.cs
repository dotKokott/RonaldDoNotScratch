using UnityEngine;
using System.Collections;

public class Needle : MonoBehaviour {

	public int Lane = 0;
	public bool Playing;

	public AudioClip NeedleDrop;
	public AudioClip NeedleUp;

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
			if (Lane < 3) {
				StartCoroutine(Move(-1));
			}
			
		}

		if (!Moving && Input.GetKeyDown(KeyCode.RightArrow)) {
			if (Lane > 0) {
				StartCoroutine(Move(1));
			}			
		}
	}	

	IEnumerator Move(int direction) {
		Moving = true;
		
		this.GetComponent<AudioSource>().PlayOneShot(NeedleUp);
		GameObject.Find( "Audio" + Lane ).GetComponent<AudioSource>().volume = 0;

		Lane -= direction;

		iTween.RotateBy(this.gameObject, iTween.Hash("x", 2.0f / 360,
													"time", 0.2f));

		

		yield return new WaitForSeconds(0.2f);

		iTween.RotateBy(this.gameObject, iTween.Hash("y", (8.0f * direction) / 360,
													"time", 0.8f));


		yield return new WaitForSeconds(0.8f);

		iTween.RotateBy(this.gameObject, iTween.Hash("x", -2.0f / 360,
													"time", 0.2f));

		GameObject.Find("Audio" + Lane).GetComponent<AudioSource>().PlayOneShot(NeedleDrop);

		yield return new WaitForSeconds(0.2f);

		var audio = GameObject.Find( "Audio" + Lane ).GetComponent<AudioSource>().volume = 1;

		Moving = false;
	}

	IEnumerator TurnOn() {
		iTween.RotateBy(this.gameObject, iTween.Hash("y", -18.0f / 360,
													"time", 3.0f));

		GameObject.Find("Vinyl").GetComponent<VinylRotate>().StartRotating();

		yield return new WaitForSeconds(3);

		iTween.RotateBy(this.gameObject, iTween.Hash("x", -2.0f / 360,
													"time", 0.8f));

		//GameObject.Find("Audio" + Lane).GetComponent<AudioSource>().PlayOneShot(NeedleDrop);
		yield return new WaitForSeconds(0.2f);


		playAll();
		GameObject.Find( "Audio" + Lane ).GetComponent<AudioSource>().volume = 1;

		Playing = true;
	}

	void playAll() {
		for ( int i = 0; i < 4; i++ ) {
			GameObject.Find( "Audio" + i ).GetComponent<AudioSource>().Play();
		}

		GameObject.Find( "BackgroundAudio" ).GetComponent<AudioSource>().volume = 1;
		GameObject.Find( "BackgroundAudio" ).GetComponent<AudioSource>().Play();
	}
}

