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

    }

    public void fireSkill()
    {

    }

    public void healSkill()
    {

    }

    public void walkRunToggle()
    {

    }
}
