using System.Collections.Generic;
using UnityEngine;
using Utilities;

public class PlaceBall : BallMovement
{
	private AimBall _aimBall;

	protected override void Awake()
	{
		base.Awake();
		_aimBall = GetComponent<AimBall>();
		_arrow.gameObject.SetActive(false);
	}

	private void Update()
	{
		ChecForClick();
		if (this.enabled)
		{
			MoveBallToStartingPosition();
		}
	}

	private void ChecForClick()
	{
		if (Input.GetMouseButtonDown(0))
		{
			SwitchToAimBall();
		}
	}

	private void SwitchToAimBall()
	{
		this.enabled = false;
		_aimBall.enabled = true;
		_arrow.gameObject.SetActive(true);
		EnableBarrierColliders(false);
	}

	private void MoveBallToStartingPosition()
	{
		Vector3 mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
		mousePosition = Vector3Extention.SetZ(mousePosition, 0f);

		List<Vector2> closestPoints = new List<Vector2>();
		foreach (Collider2D barrier in _placementBarriers)
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
