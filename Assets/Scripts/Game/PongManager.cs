using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PongManager : MonoBehaviour {

	[SerializeField]
	private int leftPlayerScore, rightPlayerScore;
	[SerializeField]
	private int winningScore = 5;

	[SerializeField]
	private Ball ball;
	[SerializeField]
	private BasePaddle leftPaddle, rightPaddle;
	[SerializeField]
	private Text leftPlayerScoreText = null, rightPlayerScoreText = null, winnerMsgDisplay = null;
	[SerializeField]
	private GameObject restartGameButton;

	[SerializeField]
	private Collider leftGoal;

	private void Start () {
		restartGameButton.SetActive(false);
		ResetScores ();

		ball.OnPlayerScore += HandlePlayerScore; 
		ball.StartMovement ();
	}

	private void ResetScores() {
		leftPlayerScore = 0;
		rightPlayerScore = 0;
	}

	private void Update () {
		if (AnyPlayerWon ()) {
			ball.StopMovement ();
			DisplayWinnerPlayerMsg ();
			restartGameButton.SetActive (true);
		}
	}

	private bool AnyPlayerWon() {
		return LeftPlayerWon () || RightPlayerWon ();
	}

	private bool LeftPlayerWon() {
		return leftPlayerScore >= winningScore;
	}

	private bool RightPlayerWon() {
		return rightPlayerScore >= winningScore;
	}

	// Called when someone scores
	private void HandlePlayerScore(object sender, BallScoreEventArgs eventArgs) {
		if (eventArgs.Collider == leftGoal) {
			rightPlayerScore++;
		} else {
			leftPlayerScore++;
		}
			
		UpdateScores ();
		ball.RestartBall ();
	}

	private void UpdateScores() {
		rightPlayerScoreText.text = rightPlayerScore.ToString();
		leftPlayerScoreText.text = leftPlayerScore.ToString();	
	}

	private void DisplayWinnerPlayerMsg() {
		winnerMsgDisplay.gameObject.SetActive (true);
		if (rightPlayerScore == winningScore) {
			winnerMsgDisplay.text = "Right player wins!";
		} else if (leftPlayerScore == winningScore) { 
			winnerMsgDisplay.text = "Left player wins!";
		}
	}

	public void RestartLevel() {
		Scene currentScene = SceneManager.GetActiveScene ();
		SceneManager.LoadScene (currentScene.name);
	}
}
