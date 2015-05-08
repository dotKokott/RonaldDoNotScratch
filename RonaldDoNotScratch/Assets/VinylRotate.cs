using UnityEngine;
using System.Collections;


public class VinylRotate : MonoBehaviour {

	public GameObject DustPrefab;
	public float RotationSpeed;

    public bool GenerateDust;

	private float currentRotationSpeed;
	// Use this for initialization
	void Start () {
	
	}

	private float timer = 0;
	void Update () {
		transform.Rotate(0, currentRotationSpeed * Time.deltaTime, 0);

        if (!GenerateDust) return;

		timer += Time.deltaTime;

		if (timer > 2) {
			timer = 0;

			var pos = transform.position;
			pos.x = -1.81f;
			pos.y = 2.78f;

			pos.x -= 0.45f * Random.Range(0, 4);

			var dust = Instantiate(DustPrefab, pos, Quaternion.identity) as GameObject;
			dust.transform.parent = this.transform;
		}

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
