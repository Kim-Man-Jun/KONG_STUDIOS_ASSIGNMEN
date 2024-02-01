using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : basicMovement
{
    [Header("Player Move")]
    [SerializeField] float walkSpeed;
    [SerializeField] float runSpeed;
    [SerializeField] float rotateSpeed;

    public static bool runOnOff = false;

    [Header("Player Attack")]
    [SerializeField] float attackPower;
    [SerializeField] float attackCoolTime;

    [Header("Player Camera")]
    [SerializeField] GameObject cam;

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

        //달리기 온오프 버튼
        //if
    }
}
