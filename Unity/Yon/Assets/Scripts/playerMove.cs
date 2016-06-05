using UnityEngine;
using System.Collections;

public class playerMove : MonoBehaviour {

	public bool canMove;
	public float maxSpeed;

	private Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (canMove) {
			if (Input.GetAxisRaw ("Horizontal") > 0.5) {
				anim.SetFloat ("LastMoveX", 1f);
			}

			if (Input.GetAxisRaw ("Horizontal") < -0.5) {
				anim.SetFloat ("LastMoveX", -1f);
			}
			if (Input.GetAxisRaw ("Vertical") > 0.5) {
				anim.SetFloat ("LastMoveY", 1f);
			}
			if (Input.GetAxisRaw ("Vertical") < -0.5) {
				anim.SetFloat ("LastMoveY", -1f);
			}


			transform.Translate(new Vector3 (0f, Input.GetAxisRaw ("Vertical") * maxSpeed * Time.deltaTime, 0f));
			transform.Translate(new Vector3 (Input.GetAxisRaw ("Horizontal") * maxSpeed * Time.deltaTime, 0f, 0f));

			anim.SetFloat ("MoveX", Input.GetAxisRaw ("Horizontal"));
			anim.SetFloat ("MoveY", Input.GetAxisRaw ("Vertical"));
			anim.SetBool ("isMoving", Mathf.Abs (Input.GetAxisRaw ("Horizontal")) > 0 || Mathf.Abs (Input.GetAxisRaw ("Vertical")) > 0);
		}

	}
}
