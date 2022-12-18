using UnityEngine;
using Utilities;

public class AimBall : MonoBehaviour
{
	private PlaceBall _placeBall;
	private Camera _camera;
	private Player _player;

	[SerializeField]
	private Transform _arrow;

	private Vector3 _mousePosition;

	private void Start()
	{
		_player = FindObjectOfType<Player>();
		_camera = Camera.main;
		_placeBall = GetComponent<PlaceBall>();
	}

	private void Update()
	{
		ChecForClick();
		SetArrow();
	}
	private void ChecForClick()
	{
		if (Input.GetMouseButtonDown(0))
		{
			ShootBall();
		}
		else if (Input.GetMouseButtonDown(1))
		{
			this.enabled = false;
			_placeBall.enabled = true;
			_arrow.gameObject.SetActive(false);
		}
	}

	private void SetArrow()
	{
		_mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);

		Vector2 playerTomouse = _player.Position - _mousePosition;
		float angle = -Vector2.SignedAngle(playerTomouse, Vector2.right) + 180f;
		_arrow.parent.localEulerAngles = Vector3Extention.SetZ(_arrow.parent.localEulerAngles, angle);
	}

	private void ShootBall()
	{
		_arrow.gameObject.SetActive(false);
		Vector2 mousePosition = _mousePosition;
		Vector2 playerPosition = _player.Position;
		_player.Shoot((mousePosition - playerPosition).normalized);
	}
}
