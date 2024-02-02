using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skillManager : MonoBehaviour
{
    playerController player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<playerController>();
    }

    public void attackOn()
    {
        player.attackOn = true;
    }

    public void posionSkill()
    {
        Debug.Log("�� ��ų ����");
        player.skill1Posion = true;
    }

    public void fireSkill()
    {
        Debug.Log("ȭ�� ��ų ����");
        player.skill2Fire = true;
    }

    public void healSkill()
    {
        Debug.Log("�� ��ų ����");
        player.skill3Heal = true;
    }

    public void walkRunToggle()
    {
        Debug.Log("�޸��� ��� ����");
        player.runOnOff = !player.runOnOff;
    }
}
