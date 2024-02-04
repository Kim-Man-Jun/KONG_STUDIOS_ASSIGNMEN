using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill2Action : MonoBehaviour
{
    public GameObject ps;

    private void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            ParticleSystem particleSystem = GetComponent<ParticleSystem>();
            ParticleCollisionEvent[] collisionEvents = new ParticleCollisionEvent[16];

            int numCollisionEvents = particleSystem.GetCollisionEvents(other, collisionEvents);

            for (int i = 0; i < numCollisionEvents; i++)
            {
                Vector3 pos = collisionEvents[i].intersection;
                GameObject boomEffect = Instantiate(ps, pos, Quaternion.identity);
                Destroy(boomEffect, 0.5f);
            }
        }
    }
}
