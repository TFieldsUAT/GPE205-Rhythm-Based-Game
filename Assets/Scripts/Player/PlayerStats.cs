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
    int baseInt;

    // these stats are use for anything to do with game or character.
    [Header("Main public Stats")]

    public int pfullHP;
    public int pcurrentHP;
    public int pSTR;
    public int pEND;
    public int pDEX;
    public int pREF;
    public int pWIS;
    public int pInt;

    public int statMathGenNumber;

    // Start is called before the first frame update
    void Start()
    {
      gameObject.transform.position = GameManager.instance.groundTiles[GameManager.instance.randomSpawnPlace];
    }

    // Update is called once per frame
    void Update()
    {

    }
    // allows stats To be compared for rolls later on in the game
    public int statGenerator(int statComparing1, int statComparing2)
    {

        statMathGenNumber = statComparing1 + statComparing2;



        return statMathGenNumber;
    }

}
