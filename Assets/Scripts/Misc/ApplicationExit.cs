using UnityEngine;

public class ApplicationExit : MonoBehaviour {

	private void Update () {
		ExitApplicationWhenEscapeIsHit ();
	}

	private void ExitApplicationWhenEscapeIsHit() {
		if (Input.GetKey ("escape")) {
			Application.Quit();
		}
	}
}
