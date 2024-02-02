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
        player.skill1Posion = true;
    }

    public void fireSkill()
    {
        player.skill2Fire = true;
    }

    public void healSkill()
    {
        player.skill3Heal = true;
    }

    public void walkRunToggle()
    {
        player.runOnOff = !player.runOnOff;
    }
}
