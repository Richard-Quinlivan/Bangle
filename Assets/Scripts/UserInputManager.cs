using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInputManager : MonoBehaviour
{

	private GameManager _gameManager;
	private StopsRemainingHandler _stopsRemainingHandler;

	private void Awake()
	{
		_gameManager = FindObjectOfType<GameManager>();
		_stopsRemainingHandler = FindObjectOfType<StopsRemainingHandler>();
	}

	private void Update()
	{
		if (Input.GetKey(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.R))
		{
			_gameManager.ReloadLevel();
		}

		if (Input.GetKeyDown(KeyCode.Space))
		{
			_stopsRemainingHandler.UseStop();
		}
	}
}
