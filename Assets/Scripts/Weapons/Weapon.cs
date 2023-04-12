using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    [Header("Generic Properties")]
    public Projectile m_proj;
    [Space]
    public bool canReload;
    [Space]
    public float magazineSize;
    [Space]
    public float reloadSpeed;
    [Space]
    public float reserveAmmo;
    [Space]
    public float currentMagazine;
    [Space]
    public float fireRate = 0.03f;
    [Space]
    [SerializeField] public WeaponState weaponState;
    [Space]
    public TMPro.TMP_Text ammoCount;
    


    [SerializeField] protected List<Projectile> bulletPool; //pool bullets of each weapon to save on instansiating


    public Vector3 defaultRotation;
    

    protected void ClearBulletPool()
    {
        bulletPool.Clear();
    }


    protected virtual void SetupBulletPool()
    {
        
        if (m_proj != null)
        {
            if (!m_proj.isHitscan) //check if projectiles are hitscan, if not, preload the weapon with bullets
            {

                currentMagazine = 0;
                int bulletCount = bulletPool.Count;
                //Fill transform of Weapon with deactivated children 
                for (int i = 0; i < magazineSize-bulletCount; i++)
                {
                    if (reserveAmmo > 0)
                    {
                        reserveAmmo-=1; //decrease ammo pool
                        Projectile tempBullet;
                        tempBullet = Instantiate(m_proj, transform);
                        tempBullet.gameObject.SetActive(false);
                        bulletPool.Add(tempBullet);//disable object for time being;
                    }
                    else
                    {
                        break; //exit, no ammo to fill
                    }
                }
                currentMagazine = bulletPool.Count;
                if (currentMagazine > 0)
                {
                    weaponState = new WS_Ready(); //set weapon to ready;
                }
                else
                {
                    weaponState = new WS_Empty(); //set weapon to empty;
                }

            }
        }
    }



    public virtual void UpdateWeapon()
    {

    }


    public virtual void manageWeapon()
    {

    }
    /// <summary>
    /// Returns weapon ammo status as a string
    /// </summary>
    /// <returns></returns>
    public virtual string GetWeaponInfo()
    {
        return  "MAG " + currentMagazine + "/" + magazineSize + "  TOTAL " + reserveAmmo;
    }

    public IEnumerator ReloadWeapon() //implement proper reload
    {

            Debug.Log("YGOOOO");
            if (bulletPool.Count < magazineSize)
            {
                weaponState = new WS_Reloading();
                yield return new WaitForSeconds(reloadSpeed);
            if (gameObject.activeSelf) // a weapon must be held to be reloaded
            {
                SetupBulletPool();
            }
            }
        
        
    }


    float lastFire = 0;
    public virtual void Fire(Transform firePosition,bool manageStates=true) //overide on a per weapon basis
    {
        if (weaponState.OP == WeaponOp.Pause)
        {
            if (Time.time - lastFire >= fireRate)
            {
                weaponState = new WS_Ready(); //set weapon state to ready
            }
        }

        if (bulletPool.Count>0 && weaponState.OP==WeaponOp.Ready)
        {
            bulletPool[0].SetOnPath(firePosition);
            bulletPool.Remove(bulletPool[0]);
            currentMagazine--;
            lastFire = Time.time;
            manageWeapon();
            if (manageStates)
            {
                if (bulletPool.Count > 0)
                {
                    weaponState = new WS_Pause();
                }
                else
                {
                    weaponState = new WS_Empty();
                }
            }
            // bulletPool[0].
        }

    }


    // Start is called before the first frame update
    void Start()
    {
       // SetupBulletPool();


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
