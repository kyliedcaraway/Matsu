using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private Animator _animator;

	private CharacterController _characterController;

	public float Speed = 5.0f;
	public float RotationSpeed = 240.0f;
	private float Gravity = 20.0f;
	private Vector3 _moveDir = Vector3.zero;

	// Use this for initialization
	void Start () {

		_animator = GetComponent<Animator> ();
		_characterController = GetComponent<CharacterController>();

	}
	
	// Update is called once per frame
	void Update () {
		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis ("Vertical");

		//limit to forward movement

		if (v < 0) {
			v = 0;
		}

		transform.Rotate (0, h * RotationSpeed * Time.deltaTime, 0);

		if (_characterController.isGrounded) 
		{
			bool move = (v > 0) || (h != 0);

			_animator.SetBool ("run", move);

			_moveDir = Vector3.forward * v;

			_moveDir = transform.TransformDirection (_moveDir);
			_moveDir *= Speed;
		
		}
		_moveDir.y -= Gravity * Time.deltaTime;

		_characterController.Move (_moveDir * Time.deltaTime);
	}
}
