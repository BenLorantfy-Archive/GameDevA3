using UnityEngine;
using System.Collections;
using WebSockets;

public class MultiplayerEngine : MonoBehaviour {
	public Server server = null;
	public GameObject player = null;

	// Use this for initialization
	void Start () {
		server = new Server (8989);

		server.OnConnect (delegate(Client client) {

			client.OnMessage(delegate(string message) {
				client.Send("Got your message:" + message);
			});
		});	
	}
	
	// Update is called once per frame
	void Update () {
		float x = player.transform.position.z;
		float y = player.transform.position.y;

		// Send player movements
		foreach (Client client in server.clients) {
			client.Send ("{ \"event\":\"movement\", \"x\":" + x + ", \"y\":" + y + "}");
		}
	}
}
