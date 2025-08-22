using Unity.VisualScripting;
using UnityEngine;

public class WeaponStats : MonoBehaviour
{
    public WeaponSO weaponsStats;
    public GameObject playerToAddedWeaponTo;
    [SerializeField] float returnTime;
    [SerializeField]Collider _weaponCollider;
    [SerializeField] bool weaponHostered;



    public void Holdingweapon()
    {
        weaponHostered = false;
        weaponsStats.holdingWeapon = true;
        returnTime = 5;

    }
    public void NotHoldingweapon()
    {
        weaponsStats.holdingWeapon = false;
        
    }

    private void Update()
    {
        if (weaponsStats.holdingWeapon)
        {
            SelectWeapon();
        }

        if (!weaponsStats.holdingWeapon && !weaponHostered && playerToAddedWeaponTo != null && gameObject.transform.position != playerToAddedWeaponTo.transform.position)
        {
            returnTime -= Time.deltaTime;
        }
      
        if( returnTime < 0 )
        {
            WeaponBackToHoster();
            returnTime = 5;
        }
    }


    public  void SelectWeapon()
    {
        if (playerToAddedWeaponTo == null)
        {
            
           playerToAddedWeaponTo = GameManager.instance.AddWeaponToPlayer(playerToAddedWeaponTo);

            if (playerToAddedWeaponTo != null)
            {
                gameObject.transform.position = playerToAddedWeaponTo.transform.position;
                gameObject.transform.parent = null;                     
            }
            else if(playerToAddedWeaponTo == null) {
                Debug.Log("Is this the weapon you want?");
            }
        }

    }

    public void WeaponBackToHoster()
    {
        
        gameObject.transform.position = playerToAddedWeaponTo.transform.position;
        weaponHostered = true;
        return;
    }

}
