using UnityEngine;
using UnityEngine.Audio;

public class SpawnManager : MonoBehaviour
{

    public GameObject enemySpawned;
    public BossFSM currentBossSpawned;
    public AudioResource bossMusicGet;
    public int bosscurrentHP;
    public int bossMusicBPM;

    private void Update()
    {
        //Checks to see is the spawn boss was found if so It Gets A few Varibles from the boss
        if(enemySpawned != null)
        {
            currentBossSpawned = enemySpawned.GetComponentInChildren<BossFSM>();
            bossMusicGet = enemySpawned.GetComponentInChildren<BossFSM>().bossMusic;
            bosscurrentHP = enemySpawned.GetComponentInChildren<BossFSM>().bossHP;
            bossMusicBPM = enemySpawned.GetComponentInChildren<BossFSM>().bossTechicallyBPM;
        }
        else
        {
            Debug.Log("No Enemy Found");
        }
    }


    //Makes The boss Spawn minions in time with the beat. It is used on audioController
     public void StartMinionSpawn()
    {
        if (enemySpawned != null)
        {
            enemySpawned.GetComponentInChildren<BossFSM>().RandomMinionToSpawn();
        }
        else
        {
            Debug.Log("Boss not found");
        }

     }
    




}
