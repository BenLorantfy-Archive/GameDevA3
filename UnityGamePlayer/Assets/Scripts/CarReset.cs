using System;
using UnityEngine;
using System.Collections;

public class CarReset : MonoBehaviour
{
    public float speed = 10;
    public bool player = false;

    private GameObject lastTrigger;
	private float counter;
	private Rigidbody rb;
    private float timer = 0;

	// Use this for initialization
	void Start () {
		rb = this.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
	    if (player)
	    {
	        if (Input.GetKeyDown(KeyCode.R))
	        {
	            Reset();
	        }
	    }
	    else
	    {
	        if (Math.Abs(this.transform.eulerAngles.z)%360< 220 & Math.Abs(this.transform.eulerAngles.z)%360 > 120)
	        {
	            timer += Time.deltaTime;
	            if (timer > 2)
	            {
	                Reset();
	            }
	        }
	        else
	        {
	            timer = 0;
	        }
	    }
	}

	void OnTriggerEnter(Collider collision) {
		if (collision.gameObject.CompareTag("ResetTrigger")) {
			lastTrigger = collision.gameObject;
		} else {
		}
	}

    public void Reset()
    {
        this.transform.position = lastTrigger.transform.position;
        this.transform.rotation = lastTrigger.transform.rotation;

        var y = lastTrigger.transform.eulerAngles.y;
        rb.velocity = new Vector3((float)Math.Sin(y * Math.PI / 180) * speed, 0, (float)Math.Cos(y * Math.PI / 180) * speed);
        rb.angularVelocity = Vector3.zero;
    }
}
