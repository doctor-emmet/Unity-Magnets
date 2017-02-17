using UnityEngine;
using System.Collections;

public class ControllerScript : MonoBehaviour {

	public float magnetStrength = 5f;
	public float distanceStretch = 10f;
	static int magnetDirection = 1; //1 = attract, -1 = repel
	public bool loseMagnet = true; 

	public GameObject player;
	public GameObject magnet;

	private Transform trans;
	private Rigidbody rb;
	private Transform magnetTrans;
	static bool magnetInZone;

	void Awake()
	{
		magnetTrans = magnet.transform;
		trans = player.transform;
		rb = player.GetComponent<Rigidbody> ();
	}

	void FixedUpdate()
	{
		if (Input.GetKey (KeyCode.RightShift)) {
			magnetInZone = false;
			Debug.Log ("This");
		}


		if (magnetInZone) {

			Vector3 directionToMagnet = magnetTrans.position - trans.position;
			float distance = Vector3.Distance (magnetTrans.position, trans.position);
			float magnetDistanceStr = (distanceStretch / distance) * magnetStrength;

			rb.AddForce (magnetDistanceStr * (directionToMagnet * magnetDirection), ForceMode.Force);
		}
	}


	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "AttractBullet") {
			magnetDirection = 1;
			magnetInZone = true;
			Debug.Log ("Craic");
		}

		if (other.tag == "RepelBullet") {
			magnetDirection = -1;
			magnetInZone = true;
			Debug.Log ("-Craic");
		}
	}

	public static void UpdateDirection(int direction)
	{
		magnetDirection = direction;
	}

	public static void UpdateZone(bool zone)
	{
		magnetInZone = zone;
	}
}

