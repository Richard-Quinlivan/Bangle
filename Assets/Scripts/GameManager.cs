using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private int _numBreakablesRemaining;

    private Player _player;
    public LevelData LevelData;
    public GameState GameState = GameState.Aiming;

    private void Awake()
    {
        _numBreakablesRemaining = FindObjectsOfType<Breakable>().Length;
        _player = FindObjectOfType<Player>();
    }

    public void ReloadLevel()
    {
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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

		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}

	public void LoseLevel()
    {
		print("You Lose");
        _player.Stop();
	}
}
