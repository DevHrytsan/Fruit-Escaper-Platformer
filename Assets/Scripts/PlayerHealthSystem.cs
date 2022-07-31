using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthSystem : MonoBehaviour
{
    public int health = 1;
    public int maxHealth = 1;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    public void GetDamage(int damage)
    {
        health -= damage;
        health = Mathf.Clamp(health, 0, maxHealth);
        if(health == 0)
        {
            GameManager.instance.Respawn();
        }

    }
}
