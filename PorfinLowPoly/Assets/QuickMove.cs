using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class QuickMove : MonoBehaviour {
	
	public float FSpeed=5.0f;
	public float FRotSpeed=50.0f;
	public float FJumpSpeed=5.0f;
	public float FGravity = 20.0F;

	
	private CharacterController FController;
	private Vector3 FMoveDir=Vector3.zero;
	private Animator FAnimator;


	public AudioSource FStepSource;
	public AudioClip[] FStepSounds;
	

	void Start()
	{
		FController = GetComponent<CharacterController>();
		FAnimator = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update () {

		float speed=0.0f;
		if (FController.isGrounded) 
		 	{
			FMoveDir = new Vector3(0, 0, Input.GetAxisRaw("Vertical"));
			FMoveDir = transform.TransformDirection(FMoveDir);
			FMoveDir *= FSpeed;
			speed=FMoveDir.magnitude;
			if (Input.GetButton("Jump"))
			{
				FAnimator.SetBool("Jump", true);
				FMoveDir.y = FJumpSpeed;
			}
			else FAnimator.SetBool("Jump", false);
		}
		FAnimator.SetFloat("Speed", speed);
		FMoveDir.y -= FGravity * Time.deltaTime;
		FController.Move(FMoveDir * Time.deltaTime);
		float val=Input.GetAxisRaw ("Horizontal");
		transform.eulerAngles = Vector3.up * (transform.eulerAngles.y+(val*FRotSpeed*Time.deltaTime));
	}

	void LeftStep()
	{
		AudioClip clip=null;
		float maxvol=1.0f;
		RaycastHit hit;
		if (Physics.Raycast(transform.position, -Vector3.up, out hit, 1.2f))//make sure this cast is long enough to reach the ground
		{
			if (hit.collider.CompareTag("Ground"))
			{
				clip=FStepSounds[0];
				maxvol=UnityEngine.Random.Range(0.2f, 0.9f);
			}
			else if (hit.collider.CompareTag("Walkway"))
			{
				clip=FStepSounds[2];
				maxvol=UnityEngine.Random.Range(0.1f, 0.5f);
			}
		}
		if (clip != null)
			FStepSource.PlayOneShot(clip, maxvol);
	}
	
	void RightStep()
	{
		AudioClip clip=null;
		float maxvol=1.0f;
		RaycastHit hit;
		if (Physics.Raycast(transform.position, -Vector3.up, out hit, 1.2f))//make sure this cast is long enough to hit the ground
		{
			if (hit.collider.CompareTag("Ground"))
			{
				clip=FStepSounds[1];
				maxvol=UnityEngine.Random.Range(0.2f, 0.9f);
			}
			else if (hit.collider.CompareTag("Walkway"))
			{
				clip=FStepSounds[3];
				maxvol=UnityEngine.Random.Range(0.05f, 0.25f);
			}
		}
		if (clip != null)
			FStepSource.PlayOneShot(clip, maxvol);
	}
	
	void LandJump()
	{
		AudioClip clip=null;
		float maxvol=1.0f;
		RaycastHit hit;
		if (Physics.Raycast(transform.position, -Vector3.up, out hit, 5.2f))//make sure this cast is long enough to hit the ground
		{
			if (hit.collider.CompareTag("Ground"))
			{
				clip=FStepSounds[4];
				maxvol=UnityEngine.Random.Range(0.2f, 0.9f);
			}
			else if (hit.collider.CompareTag("Walkway"))
			{
				clip=FStepSounds[5];
				maxvol=UnityEngine.Random.Range(0.05f, 0.25f);
			}
		}
		if (clip != null)
			FStepSource.PlayOneShot(clip, maxvol);
	}
}
