﻿using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public void RestartGame(){
		SceneManager.LoadScene(0);
		Debug.Log("Restart");
		
	}
	
}
