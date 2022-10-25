using System;
using UnityEngine;

public class StandingState : GroundedState
{
    private bool jump;
    private bool crouch;

    public StandingState(Player player, StateMachine stateMachine) : base(player, stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();
        speed = player.movementSpeed;
        crouch = false;
        jump = false;
        Debug.Log("Entering Stranding State");
    }

    public override void HandleInput()
    {
        base.HandleInput();
        crouch = Input.GetButtonDown("Fire3");
        jump = Input.GetButtonDown("Jump");
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (crouch)
        {
            stateMachine.ChangeState(player.crouching);
        }
        else if (jump)
        {
            stateMachine.ChangeState(player.jumping);
        }
    }
}
