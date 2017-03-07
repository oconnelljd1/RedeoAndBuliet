using UnityEngine;
using System.Collections;

public class DoorController : MonoBehaviour {

	private Animator anim;
	private Collider2D myCol;

	private Vector3 init, final;

	[SerializeField] private bool left, right, up, down;

	private bool open = false;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		myCol = GetComponent<Collider2D> ();
		init = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if(open){
			if (left) {
				transform.position = Vector3.MoveTowards (transform.position, init + (-transform.right * 0.64f), 1 * Time.deltaTime);
			} else if (right) {
				transform.position = Vector3.MoveTowards (transform.position, init + (transform.right * 0.64f), 1 * Time.deltaTime);
			} else if (up) {
				transform.position = Vector3.MoveTowards (transform.position, init + (transform.up * 0.64f), 1 * Time.deltaTime);
			}else if(down){
				transform.position = Vector3.MoveTowards (transform.position, init + (-transform.up * 0.64f), 1 * Time.deltaTime);
			}
		}else if (!open){
			transform.position = Vector3.MoveTowards (transform.position, init, 1 * Time.deltaTime);
		}
	}

	public void Open(){
		//myCol.enabled = false;
		open = true;
	}

	public void Close(){
		myCol.enabled = true;
		open = false;
	}

}
