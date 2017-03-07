using UnityEngine;
using System.Collections;

public class Pusher : MonoBehaviour {

	[SerializeField] private string antiBlockTag;

	private Vector3 safeT;

	// Use this for initialization
	void Start () {
		//myChar = GetComponentInParent<CharController>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		safeT = transform.position;
	}

	void OnTriggerStay2D(Collider2D trigger){
		if (trigger.CompareTag (antiBlockTag)) {
			Vector3 tempP = trigger.gameObject.transform.position;
			tempP.x -= safeT.x - transform.position.x;
			trigger.gameObject.transform.position = tempP;
			transform.position = safeT;
		}
	}
}
