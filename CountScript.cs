using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class CountScript : MonoBehaviour {

	public float targetTime = 5.0f;
	public int count;
	public Text countText;



	void awake (){
		count = 6;


		SetCountText ();
	}

	/*void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("Branch")) {
			other.gameObject.SetActive (false);
			count = count - 1;
			SetCountText ();
		}
	}*/



	void OnTriggerStay(Collider other)
	{
		if (other.gameObject.CompareTag ("Heal")) {
			Debug.Log ("InArea");
		}

		if (Input.GetKey ("space") && other.gameObject.CompareTag ("Heal")) {
			Debug.Log ("Heal1");

			targetTime -= Time.deltaTime;

			if (targetTime <= 0.0f) {

				Debug.Log ("Heal 2");
				count = count - 1;
				SetCountText ();
				healAnimation ();
				other.gameObject.SetActive (false);
				resetTimer();

			}	
		}
		if (Input.GetKeyUp ("space")) {
			resetTimer();
		}
	}

	void resetTimer (){

		targetTime = 5.0f;
	}



	void SetCountText ()
	{
		countText.text = count.ToString ();
		if (count <= 0) {
			//winText.text = "You win!";
			//SceneManager.LoadScene ("Win_Scene");
		}
	}

	void healAnimation () {

		Debug.Log ("Heal Animation");
	}
}
