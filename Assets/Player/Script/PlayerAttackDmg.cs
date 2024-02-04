using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackDmg : MonoBehaviour
{
    playerController player;
    EnemyController enemy;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<playerController>();
        enemy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            enemy.Damaged((int)player.attackPower);
        }
    }
}
