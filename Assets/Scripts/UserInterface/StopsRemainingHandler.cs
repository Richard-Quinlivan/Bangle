using TMPro;
using UnityEngine;

public class StopsRemainingHandler : MonoBehaviour
{
	private TextMeshProUGUI _stopsRemaingText;
	[SerializeField]
	private int _stopsRemainingCount;

	private GameManager _gameManager;

	private Player _player;


	private void Awake()
	{
		_gameManager = FindObjectOfType<GameManager>();
		_player = FindObjectOfType<Player>();
		_stopsRemaingText = GetComponent<TextMeshProUGUI>();

		_stopsRemainingCount = _gameManager.LevelData.NumStops;
		_stopsRemaingText.text = _stopsRemainingCount.ToString();
	}

	public void UseStop()
	{
		if (_stopsRemainingCount >= 1)
		{
			_stopsRemainingCount--;
			_stopsRemaingText.text = _stopsRemainingCount.ToString();
			_player.Stop();
		}

	}
}