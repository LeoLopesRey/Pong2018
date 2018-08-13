using UnityEngine;

public class AIPaddle : BasePaddle {

	[SerializeField]
	private float enemyAISpeed = 4.2f;

	private void Start() {
		speed = enemyAISpeed;
	}

	protected override void Control() {
		UpdateBallPosition ();
		UpdatePositionY ();
		MoveTowardsBall ();
	}

	protected void UpdateBallPosition() {
		ballPos = ballTransform.position.y;
	}

	private void MoveTowardsBall(){
		if (ball.MovingDirection () > 0f) {
			if (ballPos > transformPositionY && !touchingTopWall) {
				transform.Translate (0f, speed * Time.deltaTime, 0f);
			} else if (ballPos < transformPositionY && !touchingBottomWall) {
				transform.Translate (0f, -1f * speed * Time.deltaTime, 0f);
			}	
		}  else {
			if (transformPositionY <= 0f) {
				transform.Translate (0f, speed * Time.deltaTime, 0f);
			} else if (transformPositionY > 0.1f) {
				transform.Translate (0f, -1f * speed * Time.deltaTime, 0f);
			}
		}
	}
}
