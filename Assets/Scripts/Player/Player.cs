using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed;

    [SerializeField]
    private Rigidbody2D rb;

    public bool Shooting = false;

    public Vector3 Position
    {
        get => transform.position;
        set => transform.position = value;
    }

    public void Stop()
    {
		Debug.LogError("Game over");
        rb.velocity = Vector2.zero;
	}

    public void Shoot(Vector2 direction)
    {
        Shooting = true;
        rb.AddForce(direction * _speed, ForceMode2D.Impulse);
    }
}
