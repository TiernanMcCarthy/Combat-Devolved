using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssaultRifle : Weapon
{

    public TMPro.TMP_Text m_TextMeshPro;

    // Start is called before the first frame update
    void Start()
    {
       SetupBulletPool();
    }


    public override void Fire(Transform firePosition, bool manageStates = true)
    {
        Debug.Log("It's me, the overidden function!");
        base.Fire(firePosition);
    }
    // Update is called once per frame
    void Update()
    {
        m_TextMeshPro.text = bulletPool.Count.ToString();
    }
}
