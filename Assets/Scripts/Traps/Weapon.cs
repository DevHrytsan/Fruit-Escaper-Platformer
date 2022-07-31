using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [Header("Spread")]
    public bool useSpread;
    public float spreadAngle = 15f;
    [Header("Pelleats")]
    public int NumOfPellets = 5;

    [Header("Projectile")]
    public Rigidbody2D projectile;
    public float projectileVelocity = 40f;
    [Header("Settings")]
    public PlayerController playerController;
    public float fireRatePerSecond = 5f;
    public Transform spawnPoint;
    public GameObject muzzleFlash;
    private float lastFired = 0;
    private bool muzzleActive;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            if (Time.time - lastFired > 1f / fireRatePerSecond)
            {
                lastFired = Time.time;
                if (!muzzleActive) StartCoroutine(Muzzle());
                Debug.Log("Shoot");
                Shoot();
                //clone = Instantiate(Projectile, transform.position, transform.rotation);
                //clone.velocity = transform.TransformDirection(Vector3.forward * ProjectileSpeed);
            }
        }
    }
    public void Shoot()
    {
        if (useSpread)
        {
            for (int i = 0; i < NumOfPellets; i++)
            {
                float ang = i * spreadAngle * 3;

                Rigidbody2D projectileRelease = Instantiate(projectile, spawnPoint.position, Quaternion.Euler(ang, ang, ang));
                projectileRelease.velocity = spawnPoint.transform.right * projectileVelocity;
            }
        }
        else
        {
            Rigidbody2D projectileRelease = Instantiate(projectile, spawnPoint.position, spawnPoint.rotation);

            projectileRelease.velocity = spawnPoint.transform.right * projectileVelocity;
        }

        EZCameraShake.CameraShaker.Instance.ShakeOnce(2f, 3f, 0f, 1f);

    }
    IEnumerator Muzzle()
    {
        muzzleActive = true;
        muzzleFlash.SetActive(true);
        yield return new WaitForSeconds(.1f);
        muzzleFlash.SetActive(false);
        muzzleActive = false;
    }
}
