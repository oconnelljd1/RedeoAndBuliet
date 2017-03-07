using UnityEngine;
using System.Collections;

public class Grounder : MonoBehaviour {

	private Collider2D parentCollider;

	[SerializeField]private string[] tags;
	[SerializeField]private string playerJump;

	[SerializeField] private AudioClip land;

	CharController myChar;
	AudioSource myAudio;

	private bool grounded;

	// Use this for initialization
	void Start () {
		myChar = GetComponentInParent<CharController> ();
		parentCollider = transform.parent.gameObject.GetComponent<Collider2D> ();
		myAudio = GetComponentInParent<AudioSource> ();
	}

	void Update(){
		if(Input.GetAxis(playerJump)==0){
			Collider2D[] colliders = Physics2D.OverlapBoxAll (gameObject.transform.position, new Vector2 (0.32f, 0.1f), 0);
			bool stop = false;
			for (int i = 0; i < colliders.Length; i ++){
				for (int o = 0; o < tags.Length; o++) {
					if (colliders [i].CompareTag(tags [o])) {
						stop = true;
						break;
					}
				}
				if (stop) {
					break;
				}
			}
			if(stop){
				if (!grounded) {
					grounded = true;
					myAudio.clip = land;
					myAudio.loop = false;
					myAudio.Play ();
				}
				parentCollider.enabled = true;
				myChar.SetGrounded (true);
				myChar.SetJumping (false);
			}else{
				myChar.SetGrounded (false);
				grounded = false;
			}
		}
	}
}
