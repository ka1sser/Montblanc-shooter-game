﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destoryer : MonoBehaviour
{
    [SerializeField] float lifeTime;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }
}
