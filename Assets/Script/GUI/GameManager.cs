using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
	private string mainSceneName;

	// Use this for initialization
	void Start () {
		mainSceneName = "GameScene";
	}

	public void ChangeToPlayScene(){
		SceneManager.LoadScene (mainSceneName);
	}
}
