using UnityEngine;

public class WeaponSO : ScriptableObject
{


    //Stats For the weapons that will be added later on 
    [Header("Weapon's bonus Dmg Type")]
    public string weaponsName;
    [TextArea(3, 10)]
    public string weaponsBio;

    [Header("WeaponsHitBox")]
    public bool holdingWeapon;
    

    [Header("Type of Dmg for Weapon")]
    [SerializeField] bool bluntWeaponType;//Blunt weapons Bonus is based on STR & END stats
    [SerializeField] bool sharpWeaponType;//Sharp weapons Bonus is based on DEX & REF Stats
    [SerializeField] bool pointyWeaponType;//Pointy weapons Bonus is based on INT & WIS Stats
    [SerializeField] bool explosiveWeaponType;//Explosive weapons do not have a Bonus.
    [Header("Weapons min and Max Dmg")]
    [SerializeField] int maxDmg;
    [SerializeField] int minDmg;
    public int dmgAmount;






    //allows Me to use this to get dmg numbers for stats of weapons
    public void RandomDmgAmount()
    {
            dmgAmount = Random.Range(minDmg, maxDmg);
    }


    public void WeaponType()
    {
        if(bluntWeaponType)
        {
           
        }
        else if(sharpWeaponType)
        {

        }
        else if(pointyWeaponType)
        {

        }
        else
        {
            
        }
    }


    


}




























