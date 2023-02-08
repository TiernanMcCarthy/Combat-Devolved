using UnityEngine;
public static class WeaponOp
{
    public const int None = 0; //Unrecognised Weapon State

    public const int Ready = 1; //Ready to fire and use

    public const int Reloading = 2; //Reloading


}


[System.Serializable]
public abstract class WeaponState
{
    public byte OP { set; get; }

    public WeaponState()
    {
        OP = WeaponOp.None;
    }
}