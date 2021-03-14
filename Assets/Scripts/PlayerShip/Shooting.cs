using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public List<Transform> firePoints;
    public GameObject bulletPrefab;

    float bulletForce = 20f;
    float fireRate = 0.15f;
    float fireWait = 0f;


    void Update()
    {
        if (Input.GetButton("Fire1") && CanFire())
        {
            ShootLight();
        }
    }

    void ShootLight()
    {
        foreach(Transform _firePoint in firePoints)
        {
            GameObject _bullet = Instantiate(bulletPrefab, _firePoint.position, _firePoint.rotation);
            Rigidbody2D _rb = _bullet.GetComponent<Rigidbody2D>();
            _rb.AddForce(_firePoint.up * bulletForce, ForceMode2D.Impulse);
        }

    }

    bool CanFire()
    {
        if (Time.time >= fireWait)
        {
            fireWait = Time.time + fireRate;
            return true;
        }

        return false;
    }
}
