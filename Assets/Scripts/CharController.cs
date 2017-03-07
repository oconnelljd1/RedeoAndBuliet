using UnityEngine;
using System.Collections;

public class CharController : MonoBehaviour {

	[SerializeField]private string playerJump, playerHorizontal, playerGravity;
	[SerializeField]private string[] deadlyStrings;
	[SerializeField]private int moveSpeed;
	[SerializeField]private float jumpForce;
	private Vector3 lastPosition;

	[SerializeField]private AudioClip Jump, Move, Death, Land, Gravity;

	private bool grounded, changeGravity, jumping, movingSound = true;

	[SerializeField] private int gravity;

	private Rigidbody2D myRB;
	private AudioSource audioSource;
	private Animator myAnim;

	void OnEnable(){
		EventManager.StartListening ("SwithcGravity", SwitchGravity);
	}

	// Use this for initialization
	void Start () {
		myRB = GetComponent<Rigidbody2D> ();
		audioSource = GetComponent<AudioSource> ();
		myAnim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//Fast Fall
		if(!grounded && changeGravity && jumping){
			if (gravity < 0) {
				if (lastPosition.y < transform.position.y) {
					gravity = gravity / Mathf.Abs (gravity) * 3;
				} 
			} else if (gravity > 0) {
				if (lastPosition.y > transform.position.y) {
					gravity = gravity / Mathf.Abs (gravity) * 3;
				}
			} else {
				Debug.Log ("gravity is broken");
			}
		}else {
			gravity = gravity / Mathf.Abs (gravity) * 1;
		}
		lastPosition = transform.position;
		//Simulating Gravity
		myRB.AddForce (transform.up * -gravity);
		//moving side to side
		if (changeGravity) {
			transform.Translate (transform.right * Time.fixedDeltaTime * moveSpeed * Input.GetAxis (playerHorizontal), Space.World);
			//playing sound while moving
			if (Input.GetAxisRaw (playerHorizontal) != 0) {

				myAnim.SetBool ("2Move", true);
				if (movingSound) {
					movingSound = false;
					audioSource.clip = Move;
					audioSource.loop = true;
					audioSource.Play ();
				}
			} else if (Input.GetAxisRaw (playerHorizontal) == 0) {

				myAnim.SetBool ("2Move", false);
				movingSound = true;
				audioSource.loop = false;
			}
			//handling the direction faced
			if (Input.GetAxisRaw (playerHorizontal) != 0) {
				Vector3 tempScale = transform.localScale;
				tempScale.x = Input.GetAxisRaw (playerHorizontal);
				transform.localScale = tempScale;
			}
		}
		//handling jumping
		if(Input.GetAxisRaw(playerJump) != 0){
			if(grounded){
				Debug.Log ("Jumping");
				myAnim.SetTrigger ("2Jump");
				jumping = true;
				grounded = false;
				audioSource.clip = Jump;
				audioSource.loop = false;
				audioSource.Play ();
				myRB.AddForce (transform.up * gravity* jumpForce);
			}
		}
		//handling changing gravity
		if(Input.GetAxisRaw(playerGravity) != 0){
			if (changeGravity == true) {
				changeGravity = false;
				myAnim.SetTrigger ("2Gravity");
				audioSource.clip = Gravity;
				audioSource.loop = false;
				audioSource.Play ();
				Debug.Log (gravity);
				EventManager.TriggerEvent ("SwithcGravity");
			}
		}
		//maxing out speed when falling
		if(!changeGravity){
			if(myRB.velocity.sqrMagnitude > 1){
				myRB.velocity = myRB.velocity.normalized * 1;
			}
		}	
	}

	public void SetGrounded(bool _grounded){
		if(_grounded && !grounded){

			Debug.Log ("idling");
			myAnim.SetBool ("2Idle", true);
		}else{
			myAnim.SetBool ("2Idle", false);
		}
		grounded = _grounded;
		if(_grounded == true){
			changeGravity = true;
		}
	}

	void OnTriggerEnter2D(Collider2D trigger){
		bool stop = false;
		foreach (string deadly in deadlyStrings){
			if(trigger.CompareTag (deadly)){
				stop = true;

				break;
			}
		}
		if (stop) {

			audioSource.clip = Death;
			audioSource.loop = false;
			audioSource.Play ();
			myAnim.SetTrigger ("2Death");
			StartCoroutine ("death");
		}
	}

	public void SetJumping(bool _jumping){
		jumping = _jumping;
	}

	private IEnumerator death(){
		yield return new WaitForSeconds (1);
		GameManager.instance.Death ();
	}

	private void SwitchGravity(){
		changeGravity = false;
		Vector3 tempScale = transform.localScale;
		tempScale.y = -gravity / Mathf.Abs(gravity);
		transform.localScale = tempScale;
		GetComponent<Collider2D> ().enabled = false;
		gravity *= -1;

	}

	public string GetHAxis(){
		return playerHorizontal;
	}

}
