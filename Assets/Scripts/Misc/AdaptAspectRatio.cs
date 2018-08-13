using UnityEngine;

public class AdaptAspectRatio : MonoBehaviour {

	private void Awake() {
		Vector3 pos = Camera.main.WorldToViewportPoint (transform.position);
		pos.x = Mathf.Clamp(pos.x, 0.1f, 0.9f);
		pos.y = Mathf.Clamp01(pos.y);
		transform.position = Camera.main.ViewportToWorldPoint(pos);
	}
}
