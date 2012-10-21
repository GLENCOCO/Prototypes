using UnityEngine;
using System.Collections;

public class UnitPlayer : Unit {
	
	

	// Use this for initialization
	public override void Start () {
		base.Start();
	}
	
	// Update is called once per frame
	public override void Update () {
		//rotation
		transform.Rotate(0f,Input.GetAxis ("Mouse X") * turnSpeed * Time.deltaTime, 0f);
		
				
		//movement
		move = Vector3.zero;
		if(Input.GetKey (KeyCode.W))
			move.z++;
		if(Input.GetKey (KeyCode.S))
			move.z--;
		if(Input.GetKey (KeyCode.A))
			move.x--;
		if(Input.GetKey (KeyCode.D))
			move.x++;
		if(Input.GetKey(KeyCode.Space) && control.isGrounded)
			jump = true;
		
		move.Normalize();
		
		if(Input.GetKey (KeyCode.LeftShift))
			move *= runSpeed;
		else
			move *= walkSpeed;
		
		move = transform.TransformDirection(move);
		
		
		base.Update();
	}
}
