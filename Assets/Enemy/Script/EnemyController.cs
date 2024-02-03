using System.Collections;
using System.Collections.Generic;
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

    #endregion

    protected override void Awake()
    {
        base.Awake();

        stateMachine = new EnemyStateMachine();
    }

    protected override void Start()
    {
        base.Start();
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

    public void AnimationTrigger()
    {
        stateMachine.currentState.AnimationFinishTrigger();
    }
}
