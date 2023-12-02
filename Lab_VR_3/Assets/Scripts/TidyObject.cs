using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TidyObject : MonoBehaviour         // słuzy do usuwania kokosów
{
    public float removeTime = 3.0f;     // czas opóznienia


    void Start()
    {
        Destroy(gameObject, removeTime);
    }

}
