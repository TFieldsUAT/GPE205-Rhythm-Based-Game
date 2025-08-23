using Unity.VisualScripting;
using UnityEngine;

public class WeaponStats : MonoBehaviour
{
    public WeaponSO weaponsStats;
    public GameObject playerToAddedWeaponTo;
    [SerializeField] float returnTime;
    [SerializeField]Collider _weaponCollider;
    [SerializeField] bool weaponHostered;

    private void Start()
    {
        
    }


    public void Holdingweapon()
    {
       
        returnTime = 5;

    }
    public void NotHoldingweapon()
    {
        
    }

    private void Update()
    {
      
            SelectWeapon();
      

        if (!weaponsStats.holdingWeapon && !weaponHostered && playerToAddedWeaponTo != null && gameObject.transform.position != playerToAddedWeaponTo.transform.position)
        {
            returnTime -= Time.deltaTime;
        }
      
        if( returnTime < 0 )
        {
            WeaponBackToHoster();
            
        }
    }

    //Finds the weapon to add to player
    public  void SelectWeapon()
    {
        if (playerToAddedWeaponTo == null)
        {
            
            GameManager.instance.AddWeaponToPlayer(gameObject);

            if (playerToAddedWeaponTo != null)
            {
                gameObject.transform.position = playerToAddedWeaponTo.transform.position;
                gameObject.transform.parent = null;                     
            }
            else if(playerToAddedWeaponTo == null) {
                Debug.Log("Is this the weapon you want?");
            }
        }
        else if(playerToAddedWeaponTo != null)
        {
            return;
        }

    }

    public void WeaponBackToHoster()
    {
      
            gameObject.transform.position = playerToAddedWeaponTo.transform.position;
            returnTime = 5;
            return;
        
    }

}
