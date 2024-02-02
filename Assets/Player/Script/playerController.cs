using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : basicMovement
{
    [Header("Player Move")]
    public float xInput;
    public float zInput;
    public float walkSpeed;
    public float runSpeed;
    public float rotateSpeed;

    public static bool runOnOff = false;

    [Header("Player Attack")]
    public float attackPower;
    public float attackCoolTime;

    [Header("Player Camera")]
    public GameObject cam;

    #region stateMachine
    public PlayerStateMachine stateMachine { get; private set; }
    public PlayerIdleState idleState { get; private set; }
    public PlayerWalkState walkState { get; private set; }
    public PlayerRunState runState { get; private set; }
    #endregion

    protected override void Awake()
    {
        base.Awake();

        stateMachine = new PlayerStateMachine();

        idleState = new PlayerIdleState(this, stateMachine, "Idle");
        walkState = new PlayerWalkState(this, stateMachine, "Walk");
        runState = new PlayerRunState(this, stateMachine, "Run");
    }

    protected override void Start()
    {
        base.Start();

        stateMachine.Initialize(idleState);
    }

    protected override void Update()
    {
        base.Update();
        stateMachine.currentState.Update();
    }

    //basicMovement »ó¼Ó¿ë
    public void zeroVelocity()
    {
        ZeroVelocity();
    }
}
