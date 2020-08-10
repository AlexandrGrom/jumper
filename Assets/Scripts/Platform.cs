﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{

    [SerializeField] private Collider colision;
    void OnTriggerEnter(Collider other)
    {
        Physics.IgnoreCollision(colision, other.GetComponent<Collider>(),true);
        print("ontriggerentered");
    }

    private void OnTriggerExit(Collider other)
    {
        Physics.IgnoreCollision(colision, other.GetComponent<Collider>(),false);
        print("ontriggerexit");
    }
}
