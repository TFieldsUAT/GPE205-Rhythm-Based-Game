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
    // If either The weapon layer or the Player's DMG layer hit the enemy it does certain code on the enemy or weapon
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 6)
        {

            //Checks to see if weapon hit The enemy
            pWeaponDmg = other.GetComponentInParent<Transform>().gameObject;
            pWeaponDmg.GetComponentInParent<TempWeaponDmg>().RandomDmgAmount();
            dmgToTake = pWeaponDmg.GetComponentInParent<TempWeaponDmg>().dmgAmount;
        }
        else if (other.gameObject.layer == 10)
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
        else if (other.gameObject.layer == 10)
        {
            Debug.Log("Player Is in Attack area");
            transform.gameObject.GetComponentInParent<MinionFSM>().GettingReadyToAttack();

        }
    }

    private void OnTriggerExit(Collider other)
    {

        if (other.gameObject.layer == 6)
        {
            dmgTaken = Mathf.RoundToInt(dmgToTake);
            //Hurt The minion
            other.gameObject.GetComponentInParent<AudioSource>().Play();
            transform.gameObject.GetComponentInParent<MinionFSM>().DmgMinion(dmgTaken);
            DisplayDmg(dmgTaken);
        }
        else if (other.gameObject.layer == 10)
        {
            Debug.Log("Player move out of Attack area");
            transform.gameObject.GetComponentInParent<MinionFSM>().FindingPlayer();
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
