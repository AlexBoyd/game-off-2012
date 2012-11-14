using UnityEngine;
using System.Collections;

public class WeaponObject : MonoBehaviour
{
    public enum WeaponType
    {
        Melee,
        Ranged
    }

    public int MinSTR;
    public WeaponType Type;
    public int BaseDamage;

}
