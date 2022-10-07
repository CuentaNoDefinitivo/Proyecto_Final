using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleBullet : Bullet
{
    private void OnParticleCollision(GameObject other)
    {
        Debug.Log(other.name);
        Destroy(gameObject);
    }
}
