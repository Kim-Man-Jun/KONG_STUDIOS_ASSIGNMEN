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
    public GameObject skill1Obj;

    public bool skill2Fire;
    public GameObject skill2Obj;

    public bool skill3Heal;
    public GameObject skill3Obj;

    skillManager skillManager;

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

        skillManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<skillManager>();
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

        if (skill1Posion == true && skillManager.skill1CooltimeOn == true)
        {
            stateMachine.ChangeState(skill1State);
        }

        if (skill2Fire == true && skillManager.skill2CooltimeOn == true)
        {
            stateMachine.ChangeState(skill2State);
        }

        if (skill3Heal == true && skillManager.skill3CooltimeOn == true)
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
        playerNowHp--;

        if (playerNowHp > 1)
        {
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

    public void Skill1Instantiate()
    {
        Vector3 spawnPosition = transform.position + transform.forward * 3.0f;
        Quaternion spawnRotation = transform.rotation;

        GameObject posionTrap = Instantiate(skill1Obj, spawnPosition, spawnRotation);

        Destroy(posionTrap, 5f);
    }

    public void Skill2Instantiate()
    {
        Vector3 spawnPosition = transform.position + transform.forward * 2.0f;
        Quaternion spawnRotation = transform.rotation;

        GameObject fireball = Instantiate(skill2Obj, spawnPosition, spawnRotation);

        Destroy(fireball, 2f);
    }

    public void Skill3Instantiate()
    {
        Vector3 spawnPosition = transform.position + transform.forward * -0.05f;
        Quaternion spawnRotation = transform.rotation;

        GameObject heal = Instantiate(skill3Obj, spawnPosition, spawnRotation);

        Destroy(heal, 2f);
    }
}
