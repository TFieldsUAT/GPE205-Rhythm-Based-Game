using ExternalPropertyAttributes;
using TMPro;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    
    
    // hiddden Stats for Keeping track of characters stats, so that stats do no become negative numbers in game.
    int basefullHP;
    int basecurrentHP;
    int baseSTR;
    int baseEND;
    int baseDEX;
    int baseREF;
    int baseWIS;
    int baseINT;

    // these stats are use for anything to do with game or character.
    [Header("Main Text Stats")]
    [HorizontalLine]
    public GameObject displayHP;
    public GameObject hpText;
    public GameObject EnemiesLeft;
    public GameObject STR_TEXT;
    public GameObject END_TEXT;
    public GameObject DEX_TEXT;
    public GameObject REF_TEXT;
    public GameObject INT_TEXT;
    public GameObject WIS_TEXT;

    [Header("Main public Stats")]
    public int pfullHP;
    public int pcurrentHP;
    public int pSTR;
    public int pEND;
    public int pDEX;
    public int pREF;
    public int pWIS;
    public int pINT;

    public bool weaponCalling;
    public GameObject playerInv;
    public GameObject playerWeapon;

    public int statMathGenNumber;

    // Start is called before the first frame update
    void Start()
    {
      //gameObject.transform.position = GameManager.instance.groundTiles[GameManager.instance.randomSpawnPlace];
        pcurrentHP = 5;
        pfullHP = pcurrentHP;
    }

    // Update is called once per frame
    void Update()
    {
        hpText.GetComponent<TextMeshProUGUI>().text = pcurrentHP.ToString();
        EnemiesLeft.GetComponent<TextMeshProUGUI>().text = GameManager.instance.spawnEnemies.Count.ToString();
        
        STR_TEXT.GetComponent<TextMeshProUGUI>().text = pSTR.ToString();
        END_TEXT.GetComponent<TextMeshProUGUI>().text = pEND.ToString();
        DEX_TEXT.GetComponent<TextMeshProUGUI>().text = pDEX.ToString();
        REF_TEXT.GetComponent<TextMeshProUGUI>().text = pREF.ToString();
        INT_TEXT.GetComponent<TextMeshProUGUI>().text = pINT.ToString();
        WIS_TEXT.GetComponent<TextMeshProUGUI>().text = pWIS.ToString();

    }
    // allows stats To be compared for rolls later on in the game
    public int statGenerator(int statComparing1, int statComparing2)
    {

        statMathGenNumber = statComparing1 + statComparing2;



        return statMathGenNumber;
    }



    public void ActiveDisplay()
    {
        if(displayHP.activeSelf == false) {
        displayHP.SetActive(true);
        }
        else {
            displayHP.SetActive(false);
        }

    }


    public void SpawnPlayerBackAtHub()
    {
        gameObject.transform.position = GameManager.instance.mainMenuAreaTransform.GetComponent<mainMenuScript>().playerSpawnArea.transform.position;
        gameObject.transform.parent = null;
    }


    public void Reset()
    {
        pcurrentHP = 5;
        pfullHP = pcurrentHP;
        pSTR = baseSTR;
        pEND = baseEND;
        pDEX = baseDEX;
        pREF = baseREF;
        pINT = baseINT;
        pWIS = baseWIS;
    }






    public void SelectedWeapon()
    {
        weaponCalling = true;

    }



    public void LevelUp()
    {

        pfullHP += Random.Range(pfullHP, pfullHP + 5);
        pcurrentHP = pfullHP;
        pSTR++;
        pEND++;
        pDEX++;
        pREF++;
        pINT++;
        pWIS++;

    }
    
   

}
