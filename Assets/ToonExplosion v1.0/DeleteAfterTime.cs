using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteAfterTime : MonoBehaviour
{
    public float Time = 2f;
    void Start()
    {
        Destroy(gameObject, Time);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
