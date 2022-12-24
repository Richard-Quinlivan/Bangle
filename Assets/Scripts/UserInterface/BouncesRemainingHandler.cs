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
		    End();
		}
        _bouncesRemainingCount--;
        _bouncesRemaingText.text = _bouncesRemainingCount.ToString();
	}

	private void End()
    {
		_gameManager.LoseLevel();
	}
}
