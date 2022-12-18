using UnityEngine;
using TMPro;

public class BouncesRemainingHandler : MonoBehaviour
{
    private TextMeshProUGUI _bouncesRemaingText;
    [SerializeField]
    private int _bouncesRemainingCount;
    private Player _player;

    void Awake()
    {
        _bouncesRemaingText = GetComponent<TextMeshProUGUI>();
		_player = FindObjectOfType<Player>();
        _player.OnBarrierHit += DecrementBouncesRemaining;


        _bouncesRemaingText.text = _bouncesRemainingCount.ToString();
    }

	private void OnDestroy()
	{
		_player.OnBarrierHit -= DecrementBouncesRemaining;
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
        _player.Stop();
    }
}
