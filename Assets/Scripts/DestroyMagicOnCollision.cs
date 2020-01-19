﻿using Mirror;
using System.Collections.Generic;
using UnityEngine;

public class DestroyMagicOnCollision : NetworkBehaviour
{
    public ParticleSystem part;
    public List<ParticleCollisionEvent> collisionEvents;

    // Start is called before the first frame update
    void Start()
    {
        part = GetComponent<ParticleSystem>();
        collisionEvents = new List<ParticleCollisionEvent>();
    }

    void Update()
    {

    }

    void OnParticleCollision(GameObject other)
    {
        Destroy(this.gameObject);
    }

    
}
