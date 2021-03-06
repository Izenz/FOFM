using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
	[SerializeField] private float m_JumpForce = 400f;                          // Amount of force added when the player jumps.
	[Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;  // How much to smooth out the movement
	[SerializeField] private bool m_AirControl = false;                         // Whether or not a player can steer while jumping;
	[SerializeField] private LayerMask m_WhatIsGround;                          // A mask determining what is ground to the character
	[SerializeField] private Transform m_GroundCheck;                           // A position marking where to check if the player is grounded.
	[SerializeField] private Transform m_CeilingCheck;                          // A position marking where to check for ceilings

	const float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
	public bool m_Grounded	{ private set; get; }            // Whether or not the player is grounded.
	public bool m_DoubleJumpAvailable { private set; get; }            // Whether or not the double jump is available
	private Rigidbody2D m_Rigidbody2D;
	private bool m_FacingRight = true;  // For determining which way the player is currently facing.
	private Vector3 m_Velocity = Vector3.zero;
	private float m_RollSpeed;

	private enum State
    {
		Normal,
		Rolling,
    }
	private State state;

	[Header("Events")]
	[Space]

	public UnityEvent OnLandEvent;

	[System.Serializable]
	public class BoolEvent : UnityEvent<bool> { }

	public BoolEvent OnCrouchEvent;


	private void Awake()
	{
		if(GameManager.Instance != null)
        {
			GameManager.Instance.m_Player = gameObject;
        }

		m_Rigidbody2D = GetComponent<Rigidbody2D>();
		state = State.Normal;

		if (OnLandEvent == null)
			OnLandEvent = new UnityEvent();

		if (OnCrouchEvent == null)
			OnCrouchEvent = new BoolEvent();
	}

	private void FixedUpdate()
	{
		switch (state)
        {
			case State.Normal:
				bool wasGrounded = m_Grounded;
				m_Grounded = false;

                // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
                // This can be done using layers instead but Sample Assets will not overwrite your project settings.
                
                if (Physics2D.OverlapBox(m_GroundCheck.position, GetComponent<BoxCollider2D>().bounds.extents, 0f, m_WhatIsGround))
                {
					m_Grounded = true;
					if (!wasGrounded)
 						OnLandEvent.Invoke();
				}
				break;
			case State.Rolling:
				m_Rigidbody2D.velocity = transform.right * m_RollSpeed;
				break;
        }
		
	}


	public void Move(float move, bool jump, bool roll)
	{
        switch (state)
        {
			case State.Normal:

				//only control the player if grounded or airControl is turned on
				if (m_Grounded || m_AirControl)
				{
					// Move the character by finding the target velocity
					Vector3 targetVelocity = new Vector2(move * 10f, m_Rigidbody2D.velocity.y);
					// And then smoothing it out and applying it to the character
					m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);

					// If the input is moving the player right and the player is facing left...
					if (move > 0 && !m_FacingRight)
					{
						// ... flip the player.
						Flip();
					}
					// Otherwise if the input is moving the player left and the player is facing right...
					else if (move < 0 && m_FacingRight)
					{
						// ... flip the player.
						Flip();
					}
				}

				// If the player should jump...
				if (m_Grounded)
				{
					m_DoubleJumpAvailable = true;
				}

				if (jump)
				{
					if (m_Grounded)
					{
						// Add a vertical force to the player.
						m_Grounded = false;
						m_DoubleJumpAvailable = true;
						m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
					}
					else
					{
						if (m_DoubleJumpAvailable)
						{
							m_DoubleJumpAvailable = false;
							m_Rigidbody2D.velocity = Vector3.zero;
							m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
						}
					}
				}

                if (roll)
                {
					m_RollSpeed = 25f;
					state = State.Rolling;
                }

				break;
			case State.Rolling:

				m_RollSpeed -= m_RollSpeed * 5f * Time.deltaTime;

				if(m_RollSpeed < 5f)
                {
					state = State.Normal;
                }

				break;

        }


	}


	private void Flip()
	{
		// Switch the way the player is labelled as facing.
		m_FacingRight = !m_FacingRight;

		transform.Rotate(0f, 180f, 0f);
	}

    public void OnDrawGizmosSelected()
    {
		Gizmos.color = Color.red;
		Gizmos.DrawCube(m_GroundCheck.position, GetComponent<BoxCollider2D>().bounds.extents*2);
    }
}
