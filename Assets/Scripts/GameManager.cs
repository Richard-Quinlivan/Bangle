using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private int _numBreakablesRemaining;

    private Player _player;

    private void Awake()
    {
        _numBreakablesRemaining = FindObjectsOfType<Breakable>().Length;
        _player = FindObjectOfType<Player>();
    }

    public void BreakableHit()
    {
        _numBreakablesRemaining--;
        if (_numBreakablesRemaining == 0)
        {
            WinLevel();
        }
    }

    public void WinLevel()
    {
        print("You Win");
		_player.Stop();
	}

	public void LoseLevel()
    {
		print("You Lose");
        _player.Stop();
	}
}
