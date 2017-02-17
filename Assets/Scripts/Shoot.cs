using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

	public Rigidbody attractProjectile;
	public Rigidbody repelProjectile;
	public float speed = 20;


	void Update()
	{
		if (Input.GetButtonUp ("Fire1")) {
		
			Rigidbody instantiateProjectile = Instantiate (attractProjectile, transform.position, transform.rotation) as Rigidbody;
			instantiateProjectile.velocity = transform.TransformDirection (new Vector3 (0, 0, speed));

		}

		if (Input.GetButtonUp ("Fire2")) {

			Rigidbody instantiateProjectile = Instantiate (repelProjectile, transform.position, transform.rotation) as Rigidbody;
			instantiateProjectile.velocity = transform.TransformDirection (new Vector3 (0, 0, speed));

		}
			
	}
}
