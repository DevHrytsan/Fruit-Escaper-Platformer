using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxLauncher : MonoBehaviour
{
    [Header("Projectile")]
    public Rigidbody2D projectile;
    public float projectileVelocity = 40f;
    [Header("Settings")]
    public float fireRatePerSecond = 5f;
    public Transform spawnPoint;
    private float lastFired = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {


        if (Time.time - lastFired > 1f / fireRatePerSecond)
        {
            lastFired = Time.time;
            Rigidbody2D projectileRelease = Instantiate(projectile, spawnPoint.position, spawnPoint.rotation);
            projectileRelease.velocity = spawnPoint.transform.right * projectileVelocity;
            GameManager.instance.AddEntity(projectileRelease.gameObject);

        }




    }
}
