using UnityEngine;
using System.Collections;

public class StandardGravity : MonoBehaviour {

	private Rigidbody2D myRB;

	[SerializeField] private int Dir = 1;

	// Use this for initialization
	void Start () {
		myRB = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		myRB.AddForce(transform.up * -Dir);
	}
}
