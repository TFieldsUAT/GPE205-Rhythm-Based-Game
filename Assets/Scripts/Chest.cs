using Unity.VisualScripting;
using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField] public GameObject[] itemsAvailable;
    [SerializeField]  public int randomItemPicker;
    [SerializeField] GameObject placeToPlaceItem;
    [SerializeField] LayerMask playerLayerMask;
    [SerializeField] GameObject weaponToDetatch;
    [SerializeField] bool grabItem;
    private void Start()
    {
        //Sets The chest parent to null
        gameObject.transform.SetParent(null);
        randomItemPicker = Random.Range(0, itemsAvailable.Length);
    }

  

    public void GetItem()
    {
        
        grabItem = true;
    }


    private void Update()
    {
        //Allows the ablilty to place an item in the players inv
        if (grabItem)
        {
         placeToPlaceItem =  GameManager.instance.actors[0].GetComponent<PlayerStats>().playerInv;

           weaponToDetatch = Instantiate(itemsAvailable[randomItemPicker], placeToPlaceItem.transform);
            weaponToDetatch.transform.SetParent(null);
            Destroy(gameObject);
        }
    }

}
