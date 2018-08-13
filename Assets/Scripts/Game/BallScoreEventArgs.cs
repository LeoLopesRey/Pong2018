using System;
using UnityEngine;

public class BallScoreEventArgs : EventArgs {
	
	public Collider Collider { get; private set; }

	public BallScoreEventArgs (Collider collider) {
		Collider = collider;
	}

}
