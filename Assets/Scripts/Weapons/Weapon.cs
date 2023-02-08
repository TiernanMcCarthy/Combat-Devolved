using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    [Header("Generic Properties")]
    public Projectile m_proj;
    [Space]
    public float magazineSize;
    [Space]
    public float reloadSpeed;
    [Space]
    public float reserveAmmo;
    [Space]
    public float currentMagazine;
    [Space]
    public WeaponState weaponState;



    public Vector3 defaultRotation;
    




    // Start is called before the first frame update
    void Start()
    {
        weaponState = new WS_Ready(); //set weapon to ready;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
