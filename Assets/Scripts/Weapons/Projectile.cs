using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Header("Bullet Properties")]
    public bool isHitscan = false; //Hitscan for instant hit to target, otherwise projectile should travel
    [Space]
    public float baseDamage;
    [Space]
    public float shieldMultiplier;
    [Space]
    public float bulletSpeed;
    [SerializeField] private Decal impactDecal;


    [SerializeField] private Rigidbody rb;

    public void SetOnPath(Transform firePoint)
    {
        transform.position = firePoint.position;
        transform.forward = firePoint.forward;
        gameObject.SetActive(true);
        transform.parent = null;
        rb.velocity = transform.forward * bulletSpeed;

        


    }

}
