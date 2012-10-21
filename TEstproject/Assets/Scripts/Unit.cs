using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]

public class Unit : MonoBehaviour {
	
	protected CharacterController control;
	
	public float walkSpeed = 2f;   // meters/second
	public float runSpeed = 10f;   // meters/second
	public float turnSpeed = 90f;  // degrees/second
	public float jumpSpeed = 5f;   // meters/second
	
	protected bool jump;	
	
	protected Vector3 move = Vector3.zero;
	protected Vector3 gravity = Vector3.zero;
	// Use this for initialization
	public virtual void Start () {
	    control = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	public virtual void Update () {
		
		if(!control.isGrounded){
			gravity += Physics.gravity * Time.deltaTime;
		}
		else{
			gravity = Vector3.zero;
			
			if(jump){
				gravity.y = jumpSpeed;
				jump = false;
			}
		}
		move += gravity;

	    control.Move(move * Time.deltaTime);
	}
}
