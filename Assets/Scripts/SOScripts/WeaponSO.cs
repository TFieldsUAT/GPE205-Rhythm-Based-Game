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
    [Header("Weapons min and Max Dmg And players Stats")]
    [SerializeField] int maxDmg;
    [SerializeField] int minDmg;
    [SerializeField] int addedDmg;
    [SerializeField] PlayerStats playerStatsToGet;
    public int dmgAmount;



    private void OnEnable()
    {
        holdingWeapon = false;
    }


    //allows Me to use this to get dmg numbers for stats of weapons
    public void RandomDmgAmount()
    {
            WeaponType();
            dmgAmount = Random.Range(minDmg, maxDmg)+addedDmg;
    }


    public void WeaponType()
    {
        playerStatsToGet = GameManager.instance.actors[0].GetComponent<PlayerStats>();
      
        if (bluntWeaponType)
        {
         addedDmg =  playerStatsToGet.statGenerator(playerStatsToGet.pSTR, playerStatsToGet.pEND);
        }
        else if(sharpWeaponType)
        {
         addedDmg = playerStatsToGet.statGenerator(playerStatsToGet.pDEX, playerStatsToGet.pREF);
        }
        else if(pointyWeaponType)
        {
         addedDmg = playerStatsToGet.statGenerator(playerStatsToGet.pINT, playerStatsToGet.pWIS);
        }
        else
        {
            
        }
    }


    


}




























