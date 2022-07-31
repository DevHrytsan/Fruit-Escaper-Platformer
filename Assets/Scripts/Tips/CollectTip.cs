using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectTip : MonoBehaviour
{
    public GameObject textObject;
    public MovementTip movementTip;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.currentFruits >= 1)
        {
            textObject.SetActive(false);

        }
        else
        {
            if (movementTip.condition && movementTip.condition2)
            {
                textObject.SetActive(true);
            }
            else
            {
                textObject.SetActive(false);

            }

        }
    }
}
