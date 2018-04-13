using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovementandcamera : MonoBehaviour {

	public GameObject MatsuCamera;
	public PlayerMovement MatsuMovement;


	// Use this for initialization
	void Start () {

		MatsuMovement = GetComponent <PlayerMovement> ();
	}

	// Update is called once per frame
	void Update () {

		if (MatsuCamera.activeInHierarchy == false){

			MatsuMovement.enabled = false;
	}

		if (MatsuCamera.activeInHierarchy == true){

			MatsuMovement.enabled = true;
		}
}

}
