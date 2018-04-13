using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {


	public ParticleSystem particles;
	public float speed = 6f;
	public float horizontalrotationSpeed = 5f;


	Vector3 movement;
	Animator anim;
	Rigidbody playerRigidbody;
	//int floorMask;
	//float camRayLength = 100f;

	//INTEGER FOR COUNTING//
	private int count;

	//PUBLIC TEXT FOR COUNTING//
	public Text countText;

	//PUBLIC TEXT FOR WINNING//
	//public Text winText;





	void Awake()
	{
		//floorMask= LayerMask.GetMask ("Floor");
		anim = GetComponent <Animator> ();
		playerRigidbody = GetComponent<Rigidbody> ();

		//Count start number//
		count = 6;

		//FUNCTION CALLED TO COUNT//
		SetCountText ();

		// Call for you win text//
		//winText.text = "";

		Cursor.visible = false;

	


	}

	void FixedUpdate()
	{

		float translationforward = Input.GetAxis("Vertical") * speed;
		float translationsideways = Input.GetAxis ("Horizontal") * speed;
		float rotationleftright = Input.GetAxis("Mouse X") * horizontalrotationSpeed;
		translationforward *= Time.deltaTime;
		translationsideways *= Time.deltaTime;
		rotationleftright *= Time.deltaTime;



		transform.Translate(translationsideways, 0, translationforward);
		transform.Rotate(0, rotationleftright, 0);



		float h = Input.GetAxisRaw ("Horizontal");
		float v = Input.GetAxisRaw ("Vertical");

		//Move (h, v);
		//Turning ();
		Animating (h, v);


		float axishor = Input.GetAxis("Horizontal");

		if(axishor < 0 || axishor > 0 && !particles.isPlaying){
			particles.Play();
		}
		else if(particles.isPlaying){
			particles.Stop();
		}


		float axisvert = Input.GetAxis("Vertical");

		if(axisvert < 0 || axisvert > 0 && !particles.isPlaying){
			particles.Play();
		}
		else if(particles.isPlaying){
			particles.Stop();
		}

	}

	/* void Move (float h, float v)
	{
		movement.Set (h, 0f, v);

		movement = movement.normalized * speed * Time.deltaTime;

		playerRigidbody.MovePosition (transform.position + movement);
	} */

	/* void Turning ()
	{
		Ray camRay = Camera.main.ScreenPointToRay (Input.mousePosition);

		RaycastHit floorHit;

		if (Physics.Raycast (camRay, out floorHit, camRayLength, floorMask)) {
			Vector3 playerToMouse = floorHit.point - transform.position;
			playerToMouse.y = 0f;

			Quaternion newRotation = Quaternion.LookRotation (playerToMouse);
			playerRigidbody.MoveRotation (newRotation);
		}
	} */

	void Animating (float h, float v)
	{
		bool walking = h != 0f || v != 0f;
		anim.SetBool ("IsWalking", walking);
	}

	// TRIGGERING TREES AND GOING INACTIVE//

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("Branch")) {
			other.gameObject.SetActive (false);
			count = count - 1;
			SetCountText ();
		}
	}
		


	void SetCountText ()
	{
		countText.text = count.ToString ();
		if (count <= 0) {
			//winText.text = "You win!";
			//SceneManager.LoadScene ("Win_Scene");
		}
	} 
}

