using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {

	public int seconds = 0;
	public int best = 0;
	private TextMesh text;

	// Use this for initialization
	void Start() {
		text = GetComponent<TextMesh>();
	}

	public void StartTimer() {
		StartCoroutine( TimerThing() );
	}

	private IEnumerator TimerThing() {
		yield return new WaitForSeconds( 1 );
		seconds++;
		text.text = string.Format( "{0}:{1}", Mathf.FloorToInt( seconds / 60 ).ToString( "D2" ), ( seconds % 60 ).ToString( "D2" ) );
		StartCoroutine( TimerThing() );
	}
}
