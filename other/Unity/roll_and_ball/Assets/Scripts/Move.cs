using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Move : MonoBehaviour {
	public Text countText;
	public Text winText;
	public float speed;
	private Rigidbody rb;
	private int count;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		SetCountText ();
	}


	void FixedUpdate(){
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
		rb.AddForce (movement * speed);
	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.CompareTag ("Pick_Up")) {
			other.gameObject.SetActive(false);
			count ++;
			SetCountText();
		}
	}

	void SetCountText(){
		countText.text = "Score: " + count.ToString ();
		if (count >= 10) {
			winText.text = "You win!";
		}
	}
}
