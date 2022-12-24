using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
	[SerializeField]
	protected Transform _arrow;
	protected Camera _camera;
	protected Player _player;
	[SerializeField]
	protected GameObject _barrierParent;
	protected Collider2D[] _placementBarriers;
	private Collider2D[] _barrierColliders;
	protected GameManager _gameManager;

	protected virtual void Awake()
	{
		_player = FindObjectOfType<Player>();
		_camera = Camera.main;
		_gameManager = FindObjectOfType<GameManager>();

		_arrow.gameObject.SetActive(false);


		_placementBarriers = new Collider2D[_barrierParent.transform.childCount];
		for (int i = 0; i < _barrierParent.transform.childCount; i++)
		{
			Transform child = _barrierParent.transform.GetChild(i);
			_placementBarriers[i] = child.GetChild(0).GetComponent<Collider2D>();
		}

		_barrierColliders = _barrierParent.GetComponentsInChildren<Collider2D>();
	}

	protected void EnableBarrierColliders(bool enable)
	{
		foreach (Collider2D collider in _barrierColliders)
		{
			collider.enabled = enable;
		}
	}
}
