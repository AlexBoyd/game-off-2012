using UnityEngine;
using System.Collections;

public class BattleSystem : SingletonComponent<BattleSystem>
{
    public bool CalculateWeaponHit(Character attacker, Character defender)
    {
        switch(attacker.Weapon.Type)
        {
        case WeaponObject.WeaponType.Melee:
            return ((2 * attacker.DEX * attacker.DEX / defender.DEX) + Random.Range(1,20)) > 10;
        case WeaponObject.WeaponType.Ranged:
            return ((attacker.DEX * attacker.DEX / defender.DEX) + Random.Range(1,20)) > 10;
        default:
            return false;
        }
    }

    public int CalculateWeaponDamage(Character attacker, Character defender)
    {
        switch(attacker.Weapon.Type)
        {
        case WeaponObject.WeaponType.Melee:
            return (int)((attacker.Weapon.BaseDamage + attacker.STR - defender.Armor.BaseDMGReduction) * defender.Armor.PercentDMDReduction);
        case WeaponObject.WeaponType.Ranged:
            return (int)((attacker.Weapon.BaseDamage - defender.Armor.BaseDMGReduction) * defender.Armor.PercentDMDReduction);
        default:
            return 0;
        }
    }
}
