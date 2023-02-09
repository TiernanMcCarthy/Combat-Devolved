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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
