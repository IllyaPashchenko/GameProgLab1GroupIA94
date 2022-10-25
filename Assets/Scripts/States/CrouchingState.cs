using System;
using UnityEngine;

public class CrouchingState : GroundedState
{
    private bool belowCeiling;
    private bool crouchHeld;

    public CrouchingState(Player player, StateMachine stateMachine) : base(player, stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        speed = player.crouchSpeed;
        player.transform.localScale += new Vector3(0, -0.5f, 0);
        //player.colliderSize = player.crouchColliderHeight;
        belowCeiling = false;
        Debug.Log("Entering Crouching State");
    }

    public override void Exit()
    {
        base.Exit();
        player.transform.localScale += new Vector3(0, 0.5f, 0);
        Debug.Log("Exiting Crouching State");
        //player.colliderSize = player.normalColliderHeight;
    }

    public override void HandleInput()
    {
        base.HandleInput();
        crouchHeld = Input.GetButton("Fire3");
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (!(crouchHeld || belowCeiling))
        {
            stateMachine.ChangeState(player.standing);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        
        belowCeiling = player.CheckCollisionOverlap(player.headCheck.transform.position);
    }
}
