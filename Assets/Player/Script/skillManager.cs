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
        Debug.Log("독 스킬 실행");
    }

    public void fireSkill()
    {
        Debug.Log("화염 스킬 실행");
    }

    public void healSkill()
    {
        Debug.Log("힐 스킬 실행");
    }

    public void walkRunToggle()
    {
        Debug.Log("달리기 토글 실행");
        player.runOnOff = !player.runOnOff;
    }
}
