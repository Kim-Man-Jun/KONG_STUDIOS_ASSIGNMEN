using System.Collections;
using System.Collections.Generic;
using System.Xml;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerController : basicMovement
{
    [Header("Player Move")]
    public float xInput;
    public float zInput;
    public float walkSpeed;
    public float runSpeed;
    public float rotateSpeed;
    public bool runOnOff = false;

    [Header("Player Battle")]
    public int playerMaxHp;
    public int playerNowHp;

    public bool attackOn;
    public float attackPower;

    [Header("Player Skill")]
    public bool skill1Posion;
    public bool skill2Fire;
    public bool skill3Heal;

    [Header("Player Camera")]
    public GameObject cam;

    #region stateMachine
    public PlayerStateMachine stateMachine { get; private set; }
    public PlayerIdleState idleState { get; private set; }
    public PlayerWalkState walkState { get; private set; }
    public PlayerRunState runState { get; private set; }

    public PlayerAttackState attackState { get; private set; }
    public PlayerSkill1State skill1State { get; private set; }
    public PlayerSkill2State skill2State { get; private set; }
    public PlayerSkill3State skill3State { get; private set; }

    public PlayerHitState hitState { get; private set; }
    public PlayerVictoryState victoryState { get; private set; }
    public PlayerDeadState deadState { get; private set; }
    #endregion

    protected override void Awake()
    {
        base.Awake();

        stateMachine = new PlayerStateMachine();

        idleState = new PlayerIdleState(this, stateMachine, "Idle");
        walkState = new PlayerWalkState(this, stateMachine, "Walk");
        runState = new PlayerRunState(this, stateMachine, "Run");

        attackState = new PlayerAttackState(this, stateMachine, "Attack");
        skill1State = new PlayerSkill1State(this, stateMachine, "Skill1");
        skill2State = new PlayerSkill2State(this, stateMachine, "Skill2");
        skill3State = new PlayerSkill3State(this, stateMachine, "Skill3");

        hitState = new PlayerHitState(this, stateMachine, "Hit");
        victoryState = new PlayerVictoryState(this, stateMachine, "Victory");
        deadState = new PlayerDeadState(this, stateMachine, "Dead");
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

        if (attackOn == true)
        {
            stateMachine.ChangeState(attackState);
        }

        if (skill1Posion == true)
        {
            stateMachine.ChangeState(skill1State);
        }

        if (skill2Fire == true)
        {
            stateMachine.ChangeState(skill2State);
        }

        if (skill3Heal == true)
        {
            stateMachine.ChangeState(skill3State);
        }
    }

    //basicMovement 상속용
    public void zeroVelocity()
    {
        ZeroVelocity();
    }

    public void animationFinishTrigger()
    {
        stateMachine.currentState.AnimationFinishTrigger();
    }

    public void Damaged(int damage)
    {
        if (playerNowHp > 1)
        {
            playerNowHp--;

            stateMachine.ChangeState(hitState);
        }

        else if (playerNowHp <= 1)
        {
            StartCoroutine(playerDead());
        }
    }

    IEnumerator playerDead()
    {
        stateMachine.ChangeState(deadState);

        yield return new WaitForSeconds(1.4f);

        //재도전 패널 등장
    }
}
