using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using WebSockets;
using Newtonsoft.Json;

public class MultiplayerEngine : MonoBehaviour {
	public Server server = null;
	public GameObject player = null;
	public GameObject[] platforms = null;

	// Use this for initialization
	void Start () {
		server = new Server (8989);

		server.OnConnect (delegate(Client client) {

			client.OnMessage(delegate(string message) {
				Dictionary<string,object> data = null;
				try{
					data = JsonConvert.DeserializeObject<Dictionary<string,object>>(message);
				}catch(Exception e){
					Debug.Log("Failed to deserilize JSON:" + message);
				}

				if(data["event"].ToString() == "chat"){
					Broadcast(message);
					//Debug.Log("Got chat message: " + data["message"]);
				}

				if(data["event"].ToString() == "vote"){
					// Handle vote here with data["kind"]
					Debug.Log("A client voted for: " + data["kind"]);
				}

				//client.Send("Got your message:" + message);
			});
		});	
	}

	void Broadcast(string message){
		foreach (Client client in server.clients) {
			client.Send (message);
		}
	}
		
	
	// Update is called once per frame
	void Update () {
		float x = player.transform.position.z;
		float y = player.transform.position.y;

		// Send player movements
		Broadcast("{ \"event\":\"movement\", \"x\":" + x + ", \"y\":" + y + "}");

		// Send platform movements
		int i = 0;
		foreach (GameObject platform in platforms) {
			float platX = platform.transform.position.z;
			float platY = platform.transform.position.y;
			Broadcast("{ \"event\":\"platform\", \"x\":" + platX + ", \"y\":" + platY + ", \"i\":" + i + "}");
			i++;
		}
	}
}
