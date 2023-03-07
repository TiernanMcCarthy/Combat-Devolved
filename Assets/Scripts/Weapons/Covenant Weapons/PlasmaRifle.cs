using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlasmaRifle : Weapon
{
    [Header("Plasma Rifle Specifics")]
    public float shotCapacity = 100;
    public float fireCost; //cost for overheat
    [Space]
    public float overChargeReduction;
    [Space]
    [SerializeField] private float maxOvercharge = 100f;
    [Space]
    [SerializeField] private float overcharge = 0;
    [Space] private float shotCost = 4;

    private float increasePool = 0.5f;
    private float lastPoolIncrease = 0.5f;

    protected override void SetupBulletPool() //bullet pool with plasma rifle works different, just instansiate some as it goes on
    {
        Debug.Log("Does nothing");
        if(m_proj!=null) //ensure projectile is not null
        {
            if(currentMagazine<magazineSize)
            {
                int difference = (int)(magazineSize - currentMagazine);
                for(int i=0; i<difference; i++)
                {
                    Projectile tempBullet;
                    tempBullet = Instantiate(m_proj, transform,true);
                    tempBullet.gameObject.SetActive(false);
                    bulletPool.Add(tempBullet);//disable object for time being;
                }
                currentMagazine = magazineSize;
            }

            //weaponState = new WS_Ready();
        }

        //base.SetupBulletPool();
    }


    public override string GetWeaponInfo()
    {
        //ammoCount.text = overcharge + "/" + maxOvercharge;
        string info = "Ammo: " + shotCapacity+ "  " + overcharge + "/" + maxOvercharge;
        return info;
    }

    // Start is called before the first frame update
    void Start()
    {
        SetupBulletPool();
        weaponState = new WS_Ready();
    }

    private float lastoverCharge = 0;
    private void manageOvercharge()
    {
        overcharge = Mathf.Clamp(overcharge - overChargeReduction*Time.deltaTime,0, 100);
        Debug.Log(weaponState.OP);
        if (weaponState.OP==WeaponOp.OverCharge)
        {
            if(overcharge==0)
            {
                weaponState = new WS_Ready();
                
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        manageOvercharge();
        if(Time.time-lastPoolIncrease>=increasePool)
        {
            SetupBulletPool();
            lastPoolIncrease = Time.time;
        }
    }

    public override void manageWeapon()
    {
        //base.manageWeapon();
        overcharge += fireCost; //increase overcharge
        shotCapacity-=shotCost; //decrease ammo capacity
        if(shotCapacity<=0)
        {
            weaponState = new WS_Empty();
            ClearBulletPool();
        }
        
    }

    public override void Fire(Transform firePosition,bool manageStates=true)
    {
        if (overcharge < maxOvercharge &&weaponState.OP!=WeaponOp.OverCharge)
        {
            if (weaponState.OP == WeaponOp.Ready)
            {
                
            }
            base.Fire(firePosition,true);


            if (overcharge>=maxOvercharge)
            {
                weaponState = new WS_Overcharge();
            }
        }
        



    }
}
