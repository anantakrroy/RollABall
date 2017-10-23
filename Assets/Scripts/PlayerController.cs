using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public float speed;
	public Text countText;
	public Text winText;

	private Rigidbody rb;
	private int count;

	void Start()
	{

		rb = GetComponent<Rigidbody> ();
		count = 0;
		setCountText ();
		winText.text = "";

	}
	void FixedUpdate(){

//		The player gameObject has a rigidbody to interact with the Physics engine. The two variables below are used to record the horizontal and vertical movements 
//		from the keyboard. This input is used to add forces to the rigidbody and move the gameobject in the scene.
		float moveHorizontal = Input.GetAxis ("Horizontal"); 
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0, moveVertical);

		rb.AddForce (movement * speed);
	}

//	The reference in Collider other helps us to get a hold of the colliders we touch 
	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("PickUp")) {

			other.gameObject.SetActive (false);
			count = count + 1;
			setCountText ();
		}

	}


	void setCountText(){

		countText.text = "Count: " + count.ToString();
		if (count >= 7) {
			winText.text = "You win!!!";
		}

	}
}
	