using UnityEngine;
using UnityEngine.Audio;

public class SpawnManager : MonoBehaviour
{

    public GameObject enemySpawned;
    public BossFSM currentBossSpawned;
    public AudioResource bossMusicGet;
    public int bosscurrentHP;

    private void Update()
    {
        if(enemySpawned != null)
        {
            currentBossSpawned = enemySpawned.GetComponentInChildren<BossFSM>();
            bossMusicGet = enemySpawned.GetComponentInChildren<BossFSM>().bossMusic;
            bosscurrentHP = enemySpawned.GetComponentInChildren<BossFSM>().bossHP;
        }
        else
        {
            Debug.Log("No Enemy Found");
        }
    }




    




}
