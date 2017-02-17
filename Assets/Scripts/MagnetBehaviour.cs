using UnityEngine;
using System.Collections;

public class MagnetBehaviour : MonoBehaviour {

	public float magnetStrength = 5f;
	public float distanceStretch = 10f;
	public int magnetDirection = 1; //1 = attract, -1 = repel
	public bool loseMagnet = true;

	private Transform trans;
	private Rigidbody rb;
	private Transform magnetTrans;
	private bool magnetInZone;

	void Awake()
	{
		trans = transform;
		rb = trans.GetComponent<Rigidbody> ();
	}

	void Update()
	{
		if (Input.GetKeyDown ("space")) {

			magnetDirection = magnetDirection * -1;
			Debug.Log ("Space");
		}
	}

	void FixedUpdate()
	{
		if (magnetInZone) {

			Vector3 directionToMagnet = magnetTrans.position - trans.position;
			float distance = Vector3.Distance (magnetTrans.position, trans.position);
			float magnetDistanceStr = (distanceStretch / distance) * magnetStrength;

			rb.AddForce (magnetDistanceStr * (directionToMagnet*magnetDirection), ForceMode.Force);

		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Magnet") {

			magnetTrans = other.transform;
			magnetInZone = true;
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.tag == "Magnet" && loseMagnet) {

			magnetInZone = false;
		}
	}

}
