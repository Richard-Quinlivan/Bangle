using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed;

    [SerializeField]
    private Rigidbody2D rb;

    public Action OnBarrierHit;

    private bool _shooting = false;

    public Vector3 Position
    {
        get => transform.position;
        set => transform.position = value;
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
        if (_shooting)
        {
            OnBarrierHit?.Invoke();
        }
    }

    public void Stop()
    {
		Debug.LogError("Game over");
        rb.velocity = Vector2.zero;
	}

    public void Shoot(Vector2 direction)
    {
        _shooting = true;
        rb.AddForce(direction * _speed, ForceMode2D.Impulse);
    }
}
