﻿using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;  

public class SpawnMagic : NetworkBehaviour
{
    //Where do we cast spell from
    public GameObject MagicSpawnPoint;
    // Spell (magicBall) that we are instantiating
    public GameObject MagicBall;
    public float MagicBall_Forward_Force;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            CmdInstantiateMagicBall();
        }
    }

    [Command] public void CmdInstantiateMagicBall()
    {
        GameObject magicBallInstance;
        magicBallInstance = Instantiate(MagicBall, MagicSpawnPoint.transform.position, MagicSpawnPoint.transform.rotation) as GameObject;

        Rigidbody MagicBallCtrl;
        MagicBallCtrl = magicBallInstance.GetComponent<Rigidbody>();

        MagicBallCtrl.AddForce(transform.forward * MagicBall_Forward_Force);
        //DODANO
        Destroy(MagicBallCtrl, 3.0f);
        NetworkServer.Spawn(magicBallInstance);
        
    }
}