using TMPro;
using UnityEngine;

public class PopUpTextScript : MonoBehaviour
{
    [SerializeField] GameObject damageTextPrefab, enemyint;
    [SerializeField] string textToDisplay;
    [SerializeField] Collider enemyColider;
    [SerializeField] Transform dmgPopupArea;
    [SerializeField] GameObject pWeaponDmg;
    [SerializeField] float dmgToTake;
    [SerializeField] int dmgTaken;
    [SerializeField] GameObject damageTextInstance;
    // Start is called before the first frame update
    void Start()
    {
        enemyColider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {



    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {

            //Checks to see if weapon hit The enemy
            pWeaponDmg = other.GetComponentInParent<Transform>().gameObject;
            pWeaponDmg.GetComponentInParent<TempWeaponDmg>().RandomDmgAmount();
            dmgToTake = pWeaponDmg.GetComponentInParent<TempWeaponDmg>().dmgAmount;
        }
        else
        {
            Debug.Log(other);

        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == 6)
        {

            dmgToTake -= 0.1f * Time.deltaTime;
            if (dmgToTake < 0)
            {
                dmgToTake = 0;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.layer == 6)
        {
            dmgTaken = Mathf.RoundToInt(dmgToTake);
            //Hurt The minion
            transform.gameObject.GetComponentInParent<MinionFSM>().DmgMinion(dmgTaken);
            DisplayDmg(dmgTaken);
        }
    }



    public void DisplayDmg(float dmgDispalyed)
    {

        dmgDispalyed = Mathf.RoundToInt(dmgDispalyed);
        //Sets The Text to the dmg of the weapon
        damageTextInstance = Instantiate(damageTextPrefab, dmgPopupArea);
        damageTextInstance.transform.GetChild(0).GetComponent<TextMeshPro>().SetText(dmgDispalyed.ToString());


    }
}
