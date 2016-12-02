using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour {
	private bool movingRight = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (movingRight) {
			this.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y, this.transform.position.z - 1 * Time.deltaTime);
			if (this.transform.position.z < - 11) {
				movingRight = false;
			}
		} else {
			this.transform.position = new Vector3 (this.transform.position.x, this.transform.position.y, this.transform.position.z + 1 * Time.deltaTime);
			if (this.transform.position.z > -9) {
				movingRight = true;
			}	
		}

	}
}
