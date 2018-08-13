using UnityEngine;
using UnityEngine.UI;

public class FadeInEffectOnActive : MonoBehaviour {

	[SerializeField]
	private Image image;
	[SerializeField]
	private Text text;
	[SerializeField]
	private float alpha = 255f;
	[SerializeField]
	private float duration = 1.0f;

	void Update() {
		if (image) {
			image.CrossFadeAlpha(alpha, duration, false);
		}

		if (text) {
			text.CrossFadeAlpha(alpha, duration, false);	
		}
	}

}
