﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deleter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject NewGameObject = GameObject.Find("New Game Object");
        Destroy(NewGameObject);
    }
}
