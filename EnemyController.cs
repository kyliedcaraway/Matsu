using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour {


	public float lookRadius = 10f;

	Transform target;
	NavMeshAgent agent;
	Animator anim;


	// Use this for initialization
	void Start () {
		anim = GetComponent <Animator> ();
		target = PlayerManager.instance.player.transform;
		agent = GetComponent<NavMeshAgent> ();

	}
	
	// Update is called once per frame
	void Update () {

		float distance = Vector3.Distance (target.position, transform.position);

		if (distance <= lookRadius)
		{
			agent.enabled = true;
			agent.SetDestination (target.position);

			anim.SetBool ("NearPlayer", true);

			if (distance <= agent.stoppingDistance)
			{
				FaceTarget ();
			}
		}

		if (distance >= lookRadius)
		{
			anim.SetBool ("NearPlayer", false);
			agent.enabled = false;

		}
	}

	void FaceTarget ()
	{
		Vector3 direction = (target.position - transform.position).normalized;
		Quaternion lookRotation = Quaternion.LookRotation (new Vector3 (direction.x, 0, direction.z));
		transform.rotation = lookRotation;
		Quaternion.Slerp (transform.rotation, lookRotation, Time.deltaTime * 5f);


	}


	void OnDrawGizmosSelected ()
	{

		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, lookRadius);

	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("Player")) {
			anim.SetTrigger ("PlayerCapture");
			agent.enabled = false;

		}
	}
}
