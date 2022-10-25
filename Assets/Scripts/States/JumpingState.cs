using System;
using UnityEngine;

public class JumpingState : State
{
    private bool grounded;

    public JumpingState(Player player, StateMachine stateMachine) : base(player, stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        grounded = false;
        player.Jump();
        Debug.Log("Entering Jumping State");
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (grounded)
        {
            stateMachine.ChangeState(player.standing);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        grounded = player.CheckCollisionOverlap(player.groundCheck.transform.position);
    }

}
