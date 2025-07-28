using UnityEngine;
using UnityEngine.Audio;

public class SpawnManager : MonoBehaviour
{

    public GameObject enemySpawned;
    public BossFSM currentBossSpawned;
    public AudioResource bossMusicGet;


    private void Update()
    {
        if(enemySpawned != null)
        {
            currentBossSpawned = enemySpawned.GetComponentInChildren<BossFSM>();
            bossMusicGet = enemySpawned.GetComponentInChildren<BossFSM>().bossMusic;
        }
        else
        {
            Debug.Log("No Enemy Found");
        }
    }









}
