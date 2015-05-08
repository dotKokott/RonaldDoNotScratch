using UnityEngine;
using System.Collections;

public class DustParticle : MonoBehaviour {

	public AudioClip Scratch;

	// Use this for initialization
	IEnumerator Start() {
		yield return new WaitForSeconds( 5 );

		Destroy( this.gameObject );
	}

	// Update is called once per frame
	void Update() {

	}

	void OnTriggerEnter( Collider other ) {
		this.GetComponent<AudioSource>().PlayOneShot( Scratch );
		iTween.ShakePosition( Camera.main.gameObject, new Vector3( 0.3f, 0.1f, 0.1f ), 0.3f );

		var g = GameObject.Find( "CurrentScore" ).GetComponent<Timer>();
		var s = g.seconds;
		g.seconds = 0;

		if ( s > g.best ) {
			g.best = s;
		}

		GameObject.Find( "BestScore" ).GetComponent<TextMesh>().text = string.Format( "Best {0}:{1}", Mathf.FloorToInt( g.best / 60 ).ToString( "D2" ), ( g.best % 60 ).ToString( "D2" ) );

		
	}
}
