using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkill1State : PlayerState
{
    public PlayerSkill1State(playerController player, PlayerStateMachine stateMachine, string animBoolName) 
        : base(player, stateMachine, animBoolName)
    {

    }

    public override void Enter()
    {
        base.Enter();

        player.ZeroVelocity();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();
    }
}