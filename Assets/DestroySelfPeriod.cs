using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelfPeriod : MonoBehaviour
{
    public float Period = .1f;
    void Start()
    {
        Destroy(gameObject, Period);
    }
}
