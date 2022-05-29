using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player: MonoBehaviour
{

    public float startSpeed = 10f;
    public float speed;

    private void Start()
    {
        speed = startSpeed;
    }


}
