using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyController : basicMovement
{
    [Header("Enemy Move")]
    public float idleTime;
    public float moveSpeed;
    public float movingTime;
    public float rotateSpeed;

    [Header("Enemy Battle")]
    public int enemyMaxHp;
    public int enemyNowHp;

    #region stateMachine
    public EnemyStateMachine stateMachine { get; private set; }
    public EnemyIdleState idleState { get; private set; }
    public EnemyWalkState walkState { get; private set; }
    public EnemyAttackState attackState { get; private set; }
    public EnemyHitState hitState { get; private set; }
    public EnemyVictoryState victoryState { get; private set; }
    public EnemyDeadState deadState { get; private set; }

    public EnemyRushState rushState { get; private set; }
    #endregion

    protected override void Awake()
    {
        base.Awake();

        stateMachine = new EnemyStateMachine();

        idleState = new EnemyIdleState(this, stateMachine, "Idle");
        walkState = new EnemyWalkState(this, stateMachine, "Walk");

        attackState = new EnemyAttackState(this, stateMachine, "Attack");
        hitState = new EnemyHitState(this, stateMachine, "Hit");
        victoryState = new EnemyVictoryState(this, stateMachine, "Victory");
        deadState = new EnemyDeadState(this, stateMachine, "Dead");
        rushState = new EnemyRushState(this, stateMachine, "Rush");
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

    public void Damaged(int damage)
    {
        enemyNowHp -= damage;
    }

    public void EnemyDie()
    {
        Destroy(gameObject);
    }

    public void zeroVelocity()
    {
        ZeroVelocity();
    }

    public void AnimationTrigger()
    {
        stateMachine.currentState.AnimationFinishTrigger();
    }
}
