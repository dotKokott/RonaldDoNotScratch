using UnityEngine;
using System.Collections;


public class VinylRotate : MonoBehaviour {

	public float RotationSpeed;

	private float currentRotationSpeed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(0, currentRotationSpeed * Time.deltaTime, 0);
	}

	public void StartRotating() {
		iTween.ValueTo(this.gameObject, iTween.Hash("from", 0.0f,
													"to", RotationSpeed,
													"time", 3.0f,
													"onupdate", "onUpdate"));
	}

	void onUpdate(float value) {
		currentRotationSpeed = value;
	}
}
