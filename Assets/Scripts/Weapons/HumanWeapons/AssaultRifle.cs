using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssaultRifle : Weapon
{
    // Start is called before the first frame update
    void Start()
    {
       SetupBulletPool();
    }


    public override void Fire()
    {
        Debug.Log("It's me, the overidden function!");
        base.Fire();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
