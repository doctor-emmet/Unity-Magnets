using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetTrigger : MonoBehaviour {

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "AttractBullet") {
			ControllerScript.UpdateDirection (1);
			ControllerScript.UpdateZone (true);
		}
		if (other.tag == "RepelBullet") {
			ControllerScript.UpdateDirection (-1);
			ControllerScript.UpdateZone (true);
		}

	}
}
