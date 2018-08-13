using UnityEngine;

public class HumanPaddle : BasePaddle {

	private float verticalAxis;

	protected override void Control () {
		verticalAxis = Input.GetAxis ("Vertical");
		if ((verticalAxis>0f && !touchingTopWall) || (verticalAxis<0f && !touchingBottomWall)){
			transform.Translate (0f, verticalAxis * speed * Time.deltaTime, 0f);
		}
	}

}
