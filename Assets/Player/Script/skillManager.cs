using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class skillManager : MonoBehaviour
{
    playerController player;

    [Header("Skill CoolTime")]
    public bool skill1CooltimeOn = false;
    public float skill1Cooltime = 10;
    public Image skill1CooltimeDelay;

    public bool skill2CooltimeOn = false;
    public float skill2Cooltime = 8;
    public Image skill2CooltimeDelay;

    public bool skill3CooltimeOn = false;
    public float skill3Cooltime = 14;
    public Image skill3CooltimeDelay;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<playerController>();
    }

    private void Update()
    {
        if (skill1CooltimeOn == true)
        {
            skill1Cooltime -= Time.deltaTime;

            if (skill1Cooltime <= 0)
            {
                skill1CooltimeDelay.fillAmount = 0;
                skill1CooltimeOn = false;
            }
            else
            {
                skill1CooltimeDelay.fillAmount = skill1Cooltime / 10;
                player.skill1Posion = false;
            }
        }

        if (skill2CooltimeOn == true)
        {
            skill2Cooltime -= Time.deltaTime;

            if (skill2Cooltime <= 0)
            {
                skill2CooltimeDelay.fillAmount = 0;
                skill2CooltimeOn = false;
            }
            else
            {
                skill2CooltimeDelay.fillAmount = skill2Cooltime / 8;
                player.skill2Fire = false;
            }
        }

        if (skill3CooltimeOn == true)
        {
            skill3Cooltime -= Time.deltaTime;

            if (skill3Cooltime <= 0)
            {
                skill3CooltimeDelay.fillAmount = 0;
                skill3CooltimeOn = false;
            }
            else
            {
                skill3CooltimeDelay.fillAmount = skill3Cooltime / 14;
                player.skill3Heal = false;
            }
        }
    }

    #region Button Action
    public void attackOn()
    {
        player.attackOn = true;
    }

    public void posionSkill()
    {
        if (player.skill1Posion == false)
        {
            player.skill1Posion = true;

            skill1CooltimeOn = true;
            skill1Cooltime = 10;
        }
    }

    public void fireSkill()
    {
        if (player.skill2Fire == false)
        {
            player.skill2Fire = true;

            skill2CooltimeOn = true;
            skill2Cooltime = 8;
        }
    }

    public void healSkill()
    {
        if (player.skill3Heal == false)
        {
            player.skill3Heal = true;

            skill3CooltimeOn = true;
            skill3Cooltime = 14;
        }
    }

    public void walkRunToggle()
    {
        player.runOnOff = !player.runOnOff;
    }
    #endregion
}
