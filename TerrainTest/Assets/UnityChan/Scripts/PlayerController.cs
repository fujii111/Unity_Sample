using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	static int items;
	Rigidbody rigid;
	private Animator animator;
	private float wight = 3.0f;
	private float JumpSpeed = 2000f;
	private float jumpst;
	private float jumpnw = 0f;
	private bool jumping = true;

	void OnTriggerEnter(Collider col) {
		Destroy (col.gameObject);
		items--;
		
		
		
	}

	void Start () {
		animator = GetComponent<Animator>();
		this.rigid = GetComponent<Rigidbody> ();
		items = GameObject.FindGameObjectsWithTag ("Item").Length;
	}

	void Update () {
		if (Input.GetKey ("up")) {
			if (Input.GetKey ("left shift")) {
				transform.position += transform.forward * 0.2f;
				animator.SetBool ("is_Walk", true);
			} else if (Input.GetKeyDown("space") && this.rigid.velocity.y <= 1 && this.rigid.velocity.y >= -1) {
				animator.SetBool ("is_jumping", true);
				this.rigid.velocity = new Vector3(0, 50, 0);
			} else {
				transform.position += transform.forward * 0.6f;
				animator.SetBool ("is_Running", true);
				animator.SetBool ("is_Walk", false);
				animator.SetBool ("is_jumping", false);
			} 
		} else if (Input.GetKeyDown("space") && this.rigid.velocity.y <= 1 && this.rigid.velocity.y >= -1) {
			animator.SetBool ("is_jumping", true);
			this.rigid.velocity = new Vector3(0, 50, 0);
		} else {
			animator.SetBool("is_Running", false);
			animator.SetBool("is_Walk", false);
			animator.SetBool ("is_WalkB", false);
			animator.SetBool ("is_jumping", false);
		}
		if (Input.GetKey ("right")) {
			transform.Rotate (0, 2, 0);
		}
		
		
		
	}
}	
