using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackDmg : MonoBehaviour
{
    playerController player;
    EnemyController enemy;
    skillManager skillManager;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<playerController>();
        enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyController>();
        skillManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<skillManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            enemy.Damaged((int)player.attackPower);

            GameObject attackEffect = skillManager.GetSkillPool(skillManager.attackEffect, skillManager.attackEffectPool);
            attackEffect.transform.position = other.transform.position;
            attackEffect.SetActive(true);
            Invoke("ReturnAttackEffectPool", 0.2f);
        }
    }

    void ReturnAttackEffectPool()
    {
        GameObject attackEffect = GameObject.FindGameObjectWithTag("AttackEffect");
        skillManager.ReturnSkillPool(attackEffect, skillManager.attackEffectPool);
    }
}
