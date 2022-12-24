using System;
using UnityEngine;

public class PlayerCollider : MonoBehaviour
{
	public Action OnBarrierHit;
	private Player _player;

	private void Awake()
	{
		_player = GetComponent<Player>();
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Barrier"))
		{
			HitBarrier();
		}
	}

	private void HitBarrier()
	{
		if (_player.Shooting)
		{
			OnBarrierHit?.Invoke();
		}
	}
}
