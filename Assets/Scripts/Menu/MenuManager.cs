﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

	public void LoadScene(string name) {
		SceneManager.LoadScene (name);
	}
}
