using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUIController : MonoBehaviour
{
    public PlayerController player;

    public FixedButton jumpButton;
    public FixedButton leftButton;
    public FixedButton rightButton;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        player.jumpInput = jumpButton.Pressed;

        if (leftButton.Pressed)
        {
            player.horizontalInput = -1f;

        }
        else if (rightButton.Pressed)
        {
            player.horizontalInput = 1f;
        }
        else
        {
            player.horizontalInput = 0f;
        }
    }
}
