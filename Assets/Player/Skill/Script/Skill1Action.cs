using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill1Action : MonoBehaviour
{
    private void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("µ¶ °É¸²");
        }
    }
}
