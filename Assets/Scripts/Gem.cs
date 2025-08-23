using UnityEngine;
using UnityEngine.Rendering;

public class Gem : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    public void AllMainStatsUp()
    {
        StatUpSTR();
        StatUpDEX();
        StatUpINT();
   
    }

    public void AllSubStatsUP()
    {
        StatUpEND();
        StatUpREF();
        StatUpWIS();
    }

    public void StatUpSTR()
    {
        GameManager.instance.actors[0].GetComponent<PlayerStats>().pSTR += Random.Range(1,3);
        Destroy(gameObject);
    }
    public void StatUpEND()
    {
        GameManager.instance.actors[0].GetComponent<PlayerStats>().pEND += Random.Range(1, 3);
        Destroy(gameObject);
    }
    public void StatUpDEX()
    {
        GameManager.instance.actors[0].GetComponent<PlayerStats>().pDEX += Random.Range(1, 3);
        Destroy(gameObject);
    }
    public void StatUpREF()
    {
        GameManager.instance.actors[0].GetComponent<PlayerStats>().pREF += Random.Range(1, 3);
        Destroy(gameObject);
    }
    public void StatUpINT()
    {
        GameManager.instance.actors[0].GetComponent<PlayerStats>().pINT += Random.Range(1, 3);
        Destroy(gameObject);
    }
    public void StatUpWIS()
    {
        GameManager.instance.actors[0].GetComponent<PlayerStats>().pWIS += Random.Range(1, 3);
        Destroy(gameObject);
    }

}
