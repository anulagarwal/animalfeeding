using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentDeattacher : MonoBehaviour
{
    private void Start()
    {
        transform.parent = null;
    }
}
