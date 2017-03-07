using UnityEngine;
using System.Collections;

public class CollectableWinner : MonoBehaviour {

	public bool isRedCollectable;

	private Collider2D col;

	void Start () {
		col = gameObject.GetComponent<Collider2D> ();
	}

	void OnTriggerStay2D (Collider2D other){
		if (other.tag == "Player1" && isRedCollectable == true) {
			col.enabled = false;
			GameManager.instance.redCollectableGot = true;
			Destroy (gameObject);
		}
		else if (other.tag == "Player2" && isRedCollectable == false) {
			col.enabled = false;
			GameManager.instance.blueCollectableGot = true;
			Destroy (gameObject);
		}
	}
}
