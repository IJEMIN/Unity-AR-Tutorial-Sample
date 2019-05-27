using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetFrameRate : MonoBehaviour
{
    public int targetFrameRate = 60;
    void Start()
    {
        Application.targetFrameRate = targetFrameRate;
    }
}
