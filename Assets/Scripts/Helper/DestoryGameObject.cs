﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoryGameObject : MonoBehaviour
{
    public void Kill()
    {
        Destroy(this.gameObject);
    }
}
