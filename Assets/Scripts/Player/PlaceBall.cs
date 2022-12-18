using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Utilities;

public class PlaceBall : MonoBehaviour
{
	private Camera _camera;
	private Player _player;
	private AimBall _aimBall;

	[SerializeField]
	private Transform _arrow;
	private Collider2D[] _barriers = new Collider2D[4]; 

	private void Awake()
	{
		_player = FindObjectOfType<Player>();
		_camera = Camera.main;
		_aimBall = GetComponent<AimBall>();

		_arrow.gameObject.SetActive(false);


		_barriers = GameObject.FindGameObjectsWithTag("Barrier")
			.Select(x => x.transform.GetChild(0))
			.Select(x => x.GetComponent<Collider2D>())
			.ToArray();
	}

	private void Update()
	{
		ChecForClick();
		MoveBallToStartingPosition();
	}

	private void ChecForClick()
	{
		if (Input.GetMouseButtonDown(0))
		{
			this.enabled = false;
			_aimBall.enabled = true;
			_arrow.gameObject.SetActive(true);
		}
	}

	private void MoveBallToStartingPosition()
	{
		Vector3 mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
		mousePosition = Vector3Extention.SetZ(mousePosition, 0f);

		List<Vector2> closestPoints = new List<Vector2>();
		foreach (Collider2D barrier in _barriers)
		{
			closestPoints.Add(barrier.ClosestPoint(mousePosition));
		}

		Vector2 closestPoint = Vector2.zero;
		float smallestDistance = float.MaxValue;
		foreach (Vector2 point in closestPoints)
		{
			float distance = Vector2.Distance(mousePosition, point);
			if (distance < smallestDistance)
			{
				smallestDistance = distance;
				closestPoint = point;
			}
		}

		_player.Position = closestPoint;
	}
}
