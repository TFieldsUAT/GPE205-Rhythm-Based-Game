using UnityEngine;

public class WeaponSO : ScriptableObject
{



    [Header("Weapon's bonus Dmg Type")]
    public string weaponsName;
    [TextArea(3, 10)]
    public string weaponsBio;

    [SerializeField] bool bluntWeaponType;//Blunt weapons Bonus is based on STR & END stats
    [SerializeField] bool sharpWeaponType;//Sharp weapons Bonus is based on DEX & REF Stats
    [SerializeField] bool pointyWeaponType;//Pointy weapons Bonus is based on INT & WIS Stats
    [SerializeField] bool explosiveWeaponType;//Explosive weapons do not have a Bonus.
    [Header("Weapons min and Max Dmg")]
    [SerializeField] int maxDmg;
    [SerializeField] int minDmg;
    public int dmgAmount;

    public void RandomDmgAmount( int statOne, int statTwo)
    {
            dmgAmount = Random.Range(minDmg, maxDmg)*statOne+statTwo;
    }


}



[CreateAssetMenu(fileName = "GreatWeapon", menuName = "AFP/Weapons/GreatWeapon")]
public class GreatWeaponSo : WeaponSO
{
   
}




[CreateAssetMenu(fileName = "WhipWeapon", menuName = "AFP/Weapons/WhipWeapon")]
public class WhipWeaponSo : WeaponSO
{

}



[CreateAssetMenu(fileName = "GunAndExplosionWeapon", menuName = "AFP/Weapons/GunAndExplosionWeapon")]
public class GunAndExplosionWeaponSo : WeaponSO
{

}




[CreateAssetMenu(fileName = "BladeRifleWeapon", menuName = "AFP/Weapons/BladeRifleWeapon")]
public class BadeRifleWeaponSo : WeaponSO
{

}




[CreateAssetMenu(fileName = "BowWeapon", menuName = "AFP/Weapons/BowWeapon")]
public class BowWeaponSo : WeaponSO
{

}




[CreateAssetMenu(fileName = "SwordAndCharmWeapon", menuName = "AFP/Weapons/SwordAndCharmWeapon")]
public class SwordAndCharmWeaponSo : WeaponSO
{

}



[CreateAssetMenu(fileName = "ScytheWeapon", menuName = "AFP/Weapons/ScytheWeapon")]
public class ScytheWeaponSo : WeaponSO
{

}




[CreateAssetMenu(fileName = "HandsOfLawWeapon", menuName = "AFP/Weapons/HandsOfLawWeapon")]
public class HandOfLawsWeaponSo : WeaponSO
{

}




[CreateAssetMenu(fileName = "DaggersWeapon", menuName = "AFP/Weapons/DaggersWeapon")]
public class DaggersWeaponSo : WeaponSO
{

}




[CreateAssetMenu(fileName = "DragonClawsWeapon", menuName = "AFP/Weapons/DragonClawsWeapon")]
public class DragonClawsWeaponSo : WeaponSO
{

}





[CreateAssetMenu(fileName = "GrimourAndDaggerWeapon", menuName = "AFP/Weapons/GrimourAndDaggerWeapon")]
public class GrimourAndDagger : WeaponSO
{

}




[CreateAssetMenu(fileName = "SpearAndCatchWeapon", menuName = "AFP/Weapons/SpearAndCatch")]
public class SpearAndCatchWeapon : WeaponSO
{

}