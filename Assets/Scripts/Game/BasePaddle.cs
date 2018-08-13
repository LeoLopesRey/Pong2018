using UnityEngine;

public abstract class BasePaddle : MonoBehaviour {
	
	protected float speed = 5f;

	[SerializeField]
	protected Transform ballTransform;
	[SerializeField]
	protected Ball ball;
	protected float ballPos;

	protected float transformPositionY;

	[SerializeField]
	private Transform topWallPosition = null, bottomWallPosition = null;
	protected bool touchingBottomWall, touchingTopWall;
	private float halfWallHeight = 1.5f;
	private float TopWallPosition { get { return (topWallPosition.position.y - topWallPosition.localScale.y*halfWallHeight);} }
	private float BottomWallPosition { get { return (bottomWallPosition.position.y + bottomWallPosition.localScale.y*halfWallHeight);} }

	private void Awake() {
		touchingBottomWall = false;
		touchingTopWall = false;
	}

	private void Update () {
		UpdateOutOfBounds ();
		Control ();
	}

	protected abstract void Control();

	private void UpdateOutOfBounds() {
		UpdatePositionY ();

		if (transformPositionY > 0f && transformPositionY >= TopWallPosition ) {
			touchingTopWall = true;
		} else if (transformPositionY < 0f && transformPositionY <= BottomWallPosition ) {
			touchingBottomWall = true;
		} else {
			touchingTopWall = false;
			touchingBottomWall = false;
		}
	}

	protected void UpdatePositionY() {
		transformPositionY = gameObject.transform.position.y;
	}
}
