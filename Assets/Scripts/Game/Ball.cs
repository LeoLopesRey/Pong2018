using UnityEngine;

public class Ball : MonoBehaviour {
	
	[SerializeField][Range(-1f,1f)]
	private float initialAxisX, initialAxisY;
	private const float initialAxisZ = 0f;
	[SerializeField]
	private float speed = 5f;
	private Vector3 localVelocity;

	public event System.EventHandler<BallScoreEventArgs> OnPlayerScore;

	[SerializeField]
	private Collider leftGoal = null, rightGoal = null;

	private void Awake() {
		initialAxisX = (initialAxisX == 0f) ? GetRandomInitialAxis () : initialAxisX;
		initialAxisY = (initialAxisY == 0f) ? GetRandomInitialAxis () : initialAxisY;
	}

	private void RandomizeXYAxis() {
		initialAxisX = GetRandomInitialAxis ();
		initialAxisY = GetRandomInitialAxis ();
	}

	private float GetRandomInitialAxis() {
		return Random.Range (0f, 2f) == 0f ? -1f : 1f;
	}

	public void StartMovement() {
		gameObject.GetComponent<Rigidbody> ().velocity = new Vector3 (speed * initialAxisX, speed * initialAxisY, initialAxisZ);
	}

	public void ResetPosition() {
		transform.position = Vector3.zero;
	}

	public void RestartBall() {
		RandomizeXYAxis ();
		ResetPosition ();
		StartMovement ();
	}

	public void StopMovement() {
		ResetPosition ();
		gameObject.GetComponent<Rigidbody> ().velocity = Vector3.zero;
	}

	void OnTriggerEnter(Collider col) {
		if (col == leftGoal || col == rightGoal) {
			if (OnPlayerScore != null) { // if there are listeners to this event
				var eventArgs = new BallScoreEventArgs(col);
				OnPlayerScore(null, eventArgs);
			}
		}
	}

	public float MovingDirection() {
		localVelocity = transform.InverseTransformDirection(gameObject.GetComponent<Rigidbody> ().velocity);
		return localVelocity.x;
	}
}
