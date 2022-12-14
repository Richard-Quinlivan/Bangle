using UnityEngine;

public class Bouncer : MonoBehaviour
{
    [SerializeField]
    private float _speed;

	[SerializeField]
	private Vector2 _direction;

    [SerializeField]
    private Rigidbody2D rb;

    void Start()
    {
        rb.AddForce(_direction * _speed, ForceMode2D.Impulse);
    }

    void Update()
    {
        
    }
}
