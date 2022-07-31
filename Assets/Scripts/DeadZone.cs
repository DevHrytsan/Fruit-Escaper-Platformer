using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if (!col.transform.CompareTag("Player"))
            GameManager.instance.DeleteEntity(col.gameObject);
        else
            GameManager.instance.Respawn();
    }
}
