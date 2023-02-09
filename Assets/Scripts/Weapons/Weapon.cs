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


    [SerializeField] private List<Projectile> bulletPool; //pool bullets of each weapon to save on instansiating


    public Vector3 defaultRotation;
    

    protected void SetupBulletPool()
    {
        if (m_proj != null)
        {
            if (!m_proj.isHitscan) //check if projectiles are hitscan, if not, preload the weapon with bullets
            {
                Projectile tempBullet;
                if(currentMagazine > 0)
                {
                    reserveAmmo += currentMagazine; //add current magazine to reserve ammo
                    currentMagazine = 0;
                }
                //Fill transform of Weapon with deactivated children 
                for (int i = 0; i < magazineSize; i++)
                {
                    if (reserveAmmo > 0)
                    {
                        reserveAmmo--; //decrease ammo pool
                        currentMagazine++;
                        tempBullet = Instantiate(m_proj, transform);
                        tempBullet.gameObject.SetActive(false);
                        bulletPool.Add(tempBullet);//disable object for time being;

                    }
                    else
                    {
                        break; //exit, no ammo to fill
                    }
                }
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




    public virtual void Fire() //overide on a per weapon basis
    {
        if(bulletPool.Count>0)
        {

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
