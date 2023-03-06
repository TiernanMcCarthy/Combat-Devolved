using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public Weapon currentWeapon;
    public Weapon m_Weapon1;
    public Weapon m_Weapon2;

    public WeaponManager m_WeaponManager;

    public GameObject grenades; //dummy fix later
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKeyUp(KeyCode.Tab))
        {



            if(m_Weapon1 != null && m_Weapon2!=null)
            {
                m_Weapon1.gameObject.SetActive(!m_Weapon1.gameObject.activeSelf);
                m_Weapon2.gameObject.SetActive(!m_Weapon1.gameObject.activeSelf);
                if (m_WeaponManager.currentWeapon == m_Weapon1)
                {
                   m_WeaponManager.currentWeapon = m_Weapon2;
                   
                }
                else
                {
                    m_WeaponManager.currentWeapon = m_Weapon1;
                }
               // m_WeaponManager.currentWeapon = currentWeapon;
            }

            
        }
    }
}
