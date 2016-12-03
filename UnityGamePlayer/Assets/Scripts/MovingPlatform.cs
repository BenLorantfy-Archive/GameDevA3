using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour {
	private bool movingRight = true;
	float initialZ = 0;

	// Use this for initialization
	void Start () {
		initialZ = this.transform.position.z;
	}
	
	// Update is called once per frame
	void Update () {
		if (movingRight) {
			this.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y, this.transform.position.z - 1 * Time.deltaTime);
			if (this.transform.position.z < (initialZ - 2)) {
				movingRight = false;
			}
		} else {
			this.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y, this.transform.position.z + 1 * Time.deltaTime);
			if (this.transform.position.z > initialZ) {
				movingRight = true;
			}	
		}

	}
}
