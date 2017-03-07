using UnityEngine;
using System.Collections;

public class BlockGrounder : MonoBehaviour {

	private Collider2D[] parentColliders;
	private Rigidbody2D parentRB;

	[SerializeField]private string[] tags;

	[SerializeField] private AudioClip land;
	AudioSource myAudio;
	private bool grounded;

	// Use this for initialization
	void Start () {
		parentColliders = transform.parent.gameObject.GetComponents<Collider2D> ();
		myAudio = GetComponentInParent<AudioSource> ();
		parentRB = transform.parent.gameObject.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnTriggerStay2D(Collider2D trigger){
		bool stop = false;
		for(int i = 0; i < tags.Length; i ++){
			if(trigger.CompareTag(tags[i])){
				stop = true;
				break;
			}
		}
		if (stop) {
			if (!grounded) {
				grounded = true;
				myAudio.clip = land;
				myAudio.loop = false;
				myAudio.Play ();
			}
			foreach (Collider2D parentCollider in parentColliders) {
				parentRB.velocity = new Vector3 (0,0,0);
				parentCollider.enabled = true;
			}
		} else {
			grounded = false;
		}
	}
}
