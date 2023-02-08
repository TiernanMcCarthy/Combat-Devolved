using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    [Header("Generic Entity Components")]
    public float m_health = 100;
    public bool m_alive = true;
    public bool m_aiTarget = false; //Manages whether AI should try to attack this

    

    public virtual void RecieveDamange(float damage)
    {
        m_health-=damage;

        if(m_health < 0)
        {
            m_alive = false;
        }

    }

 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
