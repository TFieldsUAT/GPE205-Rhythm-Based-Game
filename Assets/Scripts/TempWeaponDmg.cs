using UnityEngine;

public class TempWeaponDmg : MonoBehaviour
{

    public bool holdingWeapon;
    public Collider weaponBoxHitCollider;
    [SerializeField] int maxDmg = 8;
    [SerializeField] int minDmg = 2;
    public int dmgAmount;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void RandomDmgAmount()
    {
        dmgAmount = Random.Range(minDmg, maxDmg);
    }

    public void Holdingweapon()
    {
        holdingWeapon = true;

    }
    public void NotHoldingweapon()
    {
        holdingWeapon = false;

    }
}