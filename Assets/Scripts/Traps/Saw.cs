using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : MonoBehaviour
{
    public int sawDamage = 1;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.CompareTag("Player"))
            col.gameObject.GetComponent<PlayerHealthSystem>().GetDamage(sawDamage);
    }
}
