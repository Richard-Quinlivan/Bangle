using UnityEngine;

public class Breakable : MonoBehaviour
{
	private GameManager _gameManager;

	private void Awake()
	{
		_gameManager = FindObjectOfType<GameManager>();
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Player"))
		{
			Break();	
		}
	}

	protected virtual void Break()
	{
		_gameManager.BreakableHit();
		Destroy(gameObject);
	}
}
