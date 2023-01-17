using UnityEngine;
using TMPro;

public class BouncesRemainingHandler : MonoBehaviour
{
    private TextMeshProUGUI _bouncesRemaingText;
    [SerializeField]
    private int _bouncesRemainingCount;
    private PlayerCollider _playerCollider;

	private GameManager _gameManager;


	void Awake()
    {
		_gameManager = FindObjectOfType<GameManager>();
		_bouncesRemaingText = GetComponent<TextMeshProUGUI>();
		_playerCollider = FindObjectOfType<PlayerCollider>();
        _playerCollider.OnBarrierHit += DecrementBouncesRemaining;

		_bouncesRemainingCount = _gameManager.LevelData.NumBounces;
		_bouncesRemaingText.text = _bouncesRemainingCount.ToString();
    }

	private void OnDestroy()
	{
		_playerCollider.OnBarrierHit -= DecrementBouncesRemaining;
	}

	private void DecrementBouncesRemaining()
	{
		if (_bouncesRemainingCount <= 1)
		{
			_gameManager.LoseLevel();
		}
		_bouncesRemainingCount--;
		_bouncesRemaingText.text = _bouncesRemainingCount.ToString();
	}
}
