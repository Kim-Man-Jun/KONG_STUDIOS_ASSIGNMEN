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

    public void posionSkill()
    {
        Debug.Log("�� ��ų ����");
    }

    public void fireSkill()
    {
        Debug.Log("ȭ�� ��ų ����");
    }

    public void healSkill()
    {
        Debug.Log("�� ��ų ����");
    }

    public void walkRunToggle()
    {
        Debug.Log("�޸��� ��� ����");
        player.runOnOff = !player.runOnOff;
    }
}
