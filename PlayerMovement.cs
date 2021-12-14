using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	//modified player movement script
	// This is a reference to the Rigidbody component called "rb"
	public Rigidbody rb;

	//public float forwardForce = 2000f;  // Variable that determines the forward force
	//public float sidewaysForce = 500f;  // Variable that determines the sideways force
	public float turnSpeed;
	public float distancetoGround;


	public Animator characterAnim;

	public bool isGrounded()
	{    // Check if in contact with ground
		return Physics.Raycast(transform.position, -Vector3.up, distancetoGround + 0.1f);
	}

	Transform direction;

	private void Start()
	{
		direction = this.transform;
		distancetoGround = GetComponent<Collider>().bounds.extents.y;
	}
	void FixedUpdate()
	{
		Movement();
		this.transform.Rotate(0, Input.GetAxis("Horizontal") * 70 * Time.deltaTime, 0);
	}

    private void Update()
    {
		HandleAnimations();
		Jump();
	}

	private void HandleAnimations()
	{
		if (!isGrounded())
		{
			characterAnim.SetBool("isJumping", true);
		}
        else
        {
			characterAnim.SetBool("isJumping", false);
		}


	}

	void Movement()
	{
		if (Input.GetKey("w"))  // If the player is pressing the "w" key
		{
			characterAnim.SetBool("isRunning",true);
			rb.AddForce(direction.forward * 30);
		}

		if (Input.GetKey("s"))  // If the player is pressing the "s" key
		{
			characterAnim.SetBool("isRunning", true);
			rb.AddForce(-direction.forward * 30);
		}
		if( Input.GetAxis("Vertical") == 0)
        {
			characterAnim.SetBool("isRunning", false);
		}

		if (rb.position.y < -1f)
		{
			FindObjectOfType<GameManager>().EndGame();
		}
	}

	void Jump()
	{
		if (Input.GetButtonDown("Jump") && isGrounded()) //if the player is on the ground and is grounded
		{
			rb.AddForce(rb.centerOfMass + new Vector3(0f, 10, 0f), ForceMode.Impulse);
			characterAnim.SetBool("isJumping", true);
			//characterAnim.Play("Jump");
		}
	}
}
