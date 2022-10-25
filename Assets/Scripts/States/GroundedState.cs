using System;
using UnityEngine;

public class GroundedState : State
{
    protected float speed;

    private float horizontalInput;

    public GroundedState(Player player, StateMachine stateMachine) : base(player, stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        horizontalInput = 0.0f;
    }

    public override void Exit()
    {
        base.Exit();
        player.ResetMoveParams();
    }

    public override void HandleInput()
    {
        base.HandleInput();
        horizontalInput = Input.GetAxis("Horizontal");
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        player.Move(horizontalInput, speed);
    }
}
