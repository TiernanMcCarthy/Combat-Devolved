using UnityEngine;
[System.Serializable]
public static class WeaponOp
{
    public const int None = 0; //Unrecognised Weapon State

    public const int Ready = 1; //Ready to fire and use

    public const int Reloading = 2; //Reloading

    public const int Empty = 3; //Empty Weapon

    public const int Pause = 4; //Weapon Pause between firing

    public const int OverCharge = 5; //Weapon is overcharging


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