using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FruitsCounter : MonoBehaviour
{
    public TMP_Text fruitText;


    int currentFruits;
    int maxFruits;
    // Update is called once per frame
    void Update()
    {
        currentFruits = GameManager.instance.currentFruits;
        maxFruits = GameManager.instance.maxFruits;

        if (currentFruits == maxFruits)
        {
            fruitText.text = "PORTAL ACTIVE";
        }
        else
        {
            fruitText.text = $"FRUITS:{currentFruits}/{maxFruits}";
        }
    }
}
