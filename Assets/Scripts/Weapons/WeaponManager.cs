using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{

    public Camera m_weaponCam; //Depth only camera used to render player weapons 

    public MoveCamera m_mainCamera; //player camera, used to work out weapon sway

    public Weapon currentWeapon;

    public float maxSwayDistance = 0.15f;

    public float maxRotation = 10.0f;

    public float minimumSwayForce = 0.3f;

    public float swaySpeed;

    public bool firstPerson; //player flag

    private float lastY; //Y =horizontal

    private float lastX; //X =Vertical



    Vector3 originalPosition;
    Quaternion lastRotation;

    static public float ModularClamp(float val, float min, float max, float rangemin = -180f, float rangemax = 180f)
    {
        var modulus = Mathf.Abs(rangemax - rangemin);
        if ((val %= modulus) < 0f) val += modulus;
        return Mathf.Clamp(val + Mathf.Min(rangemin, rangemax), min, max);
    }


    // Start is called before the first frame update
    void Start()
    {
        m_weaponCam.gameObject.SetActive(false);
        m_weaponCam.gameObject.SetActive(true);


        //lastY = 
       // lastX = m_mainCamera.transform.eulerAngles.x;
        originalPosition = currentWeapon.transform.localPosition;
    }
    //return angle in range -180 to 180
    float NormalizeAngle(float a)
    {
        return a - 180f * Mathf.Floor((a + 180f) / 180f);
    }


    private void SwayWeapon()
    {

        currentWeapon.transform.localPosition += new Vector3((lastY-m_mainCamera.transform.localRotation.y)*Time.deltaTime,0,0);
        
        currentWeapon.transform.localPosition += new Vector3(0,(lastX - m_mainCamera.transform.localRotation.x) * Time.deltaTime, 0);


        lastY = m_mainCamera.transform.localRotation.y;
        lastX = m_mainCamera.transform.localRotation.x;

       
    }

    // Update is called once per frame
    void Update()
    {
        if (firstPerson)
        {
            SwayWeapon();

        }

        
    }


    private void CheckWeaponStates()
    {
        //if()
    }



    private void FixedUpdate()
    {
      
    }
}
