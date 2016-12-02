using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	public GameObject mainCamera = null;
	public GameObject player = null;
	float deltaY = 0;

	// Use this for initialization
	void Start () {
		deltaY = mainCamera.transform.position.y - player.transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		mainCamera.transform.position = new Vector3 (mainCamera.transform.position.x, player.transform.position.y + deltaY, player.transform.position.z);

	}
}
