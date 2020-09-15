﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public GameObject DoorU;
    public GameObject DoorR;
    public GameObject DoorD;
    public GameObject DoorL;

    public Material[] Meshes;

    private void Start()
    {
        foreach (var comp in GetComponentsInChildren<Component>())
        {
            if (comp.name == "floor")
            {
                var material = comp.GetComponentsInChildren<Renderer>();
                material[0].material = Meshes[Random.Range(0, Meshes.Length)];
            }
        }
    }

    public void RotateRandomly()
    {
        int count = Random.Range(0, 4);

        for (int i = 0; i < count; i++)
        {
            transform.Rotate(0, 90, 0);

            GameObject tmp = DoorL;
            DoorL = DoorD;
            DoorD = DoorR;
            DoorR = DoorU;
            DoorU = tmp;
        }
    }
}
