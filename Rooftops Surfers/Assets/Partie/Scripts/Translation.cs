using System;
using UnityEngine;

public class Translation : MonoBehaviour
{
    public float x;
    private void Update()
    {
        transform.Translate(x * Time.deltaTime, 0, 0);
    }
}