﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddRoom : MonoBehaviour
{

    private RoomTemplates templates;


    void Start()
    {
        templates = GameObject.FindGameObjectWithTag("Room").GetComponent<RoomTemplates>();
        templates.rooms.Add(this.gameObject);
    }

   
}
