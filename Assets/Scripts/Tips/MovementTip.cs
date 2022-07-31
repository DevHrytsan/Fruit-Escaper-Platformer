using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTip : MonoBehaviour
{
    public bool condition;
    public bool condition2;
    public GameObject textObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Horizontal") > 0)
            condition = true;
        if (Input.GetButton("Jump"))
            condition2 = true;

        if(condition && condition2)
        {
            textObject.SetActive(false);
        }
        else
        {
            textObject.SetActive(true);
        }

    }
    public void Reactive()
    {
        
    }
}
