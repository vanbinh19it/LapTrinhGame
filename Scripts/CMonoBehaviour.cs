using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CMonoBehaviour : MonoBehaviour
{ 
    protected virtual void Reset() {
        LoadComponents();
    }

    protected virtual void Awake() {
        LoadComponents();
    }
    protected virtual void LoadComponents()
    {
        
    }
}