using UnityEngine;
using System.Collections;

public class BlockController : MonoBehaviour {

	private Rigidbody2D myRB;
	private Collider2D[] myCols;

	[SerializeField]private bool notPurple = true;

	[SerializeField]private int myGravity = 0;
	private int redGravity = 1, blueGravity = -1;

	void OnEnable(){
		EventManager.StartListening ("SwithcGravity", SwitchGravity);
	}

	// Use this for initialization
	void Start () {
		myRB = GetComponent<Rigidbody2D> ();
		myCols = GetComponents<Collider2D> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		myRB.AddForce (transform.up * -myGravity);
		if(myRB.velocity.sqrMagnitude > 1){
			myRB.velocity = myRB.velocity.normalized * 1;
		}
	}

	private void SwitchGravity(){
		Debug.Log ("Switching Gravity");
		foreach (Collider2D myCol in myCols) {
			myCol.enabled = false;
		}
		if(notPurple){
			myGravity *= -1;
		}else{
			redGravity *= -1;
			blueGravity *= -1;
			if (Input.GetAxisRaw ("p1g") != 0) {
				myGravity = redGravity;
			} else if (Input.GetAxisRaw("p2g") != 0) {
				myGravity = blueGravity;
			}else{
				Debug.Log ("Purple Broken");
			}
		}
		Vector3 tempScale = transform.localScale;
		tempScale.y = myGravity;
		transform.localScale = tempScale;
	}


}
