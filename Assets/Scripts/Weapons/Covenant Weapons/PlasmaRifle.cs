using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlasmaRifle : Weapon
{
    [Header("Plasma Rifle Specifics")]
    public float fireCost; //cost for overheat
    [Space]
    public float overChargeReduction;
    [Space]
    [SerializeField] private float maxOvercharge = 100f;
    [Space]
    [SerializeField] private float overcharge = 0;

    protected override void SetupBulletPool() //bullet pool with plasma rifle works different, just instansiate some as it goes on
    {
        Debug.Log("Does nothing");
        //base.SetupBulletPool();
    }


    // Start is called before the first frame update
    void Start()
    {
        SetupBulletPool();
    }

    private float lastoverCharge = 0;
    private void manageOvercharge()
    {
        overcharge = Mathf.Clamp(overcharge - overChargeReduction*Time.deltaTime,0, 100);
    }
    // Update is called once per frame
    void Update()
    {
        manageOvercharge();

    }



    public override void Fire(Transform firePosition)
    {
        if (overcharge < maxOvercharge)
        {
            overcharge += fireCost;
            base.Fire(firePosition);
        }



    }
}
