using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    public StateMachine movementSM;
    public StandingState standing;
    public JumpingState jumping;
    public CrouchingState crouching;
    public float movementSpeed = 5f;
    public float jumpForce = 14f;
    public float crouchSpeed = 2f;
    //public float crouchColliderHeight = 0.5f;
    //public float normalColliderHeight = 1f;
    public GameObject groundCheck;
    public GameObject headCheck;

    [SerializeField] LayerMask ground;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        movementSM = new StateMachine();

        standing = new StandingState(this, movementSM);
        crouching = new CrouchingState(this, movementSM);
        jumping = new JumpingState(this, movementSM);

        movementSM.Initialize(standing);
    }

    // Update is called once per frame
    public void Move(float direction, float speed)
    {
        rb.velocity = new Vector2(direction * speed, rb.velocity.y);
    }

    public void Jump()
    {
        if (Input.GetKeyDown("space"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    public void ResetMoveParams()
    {
        rb.velocity = Vector2.zero;
    }

    public bool CheckCollisionOverlap(Vector2 point)
    {
        return Physics2D.OverlapCircle(point, 0.1f, ground);
    }

    private void Update()
    {
        movementSM.CurrentState.HandleInput();

        movementSM.CurrentState.LogicUpdate();

        movementSM.CurrentState.PhysicsUpdate();

    }
}
