using System.Linq;
using UnityEngine;
using UnityEngine.Audio;
using static MagicSO;

public class BossFSM : MonoBehaviour
{
    //All var Need for boss to function as of right now
    public AudioResource bossMusic;
    public int bossTechicallyBPM;
    [SerializeField] GameObject[] minionsToSpawn;
    [SerializeField] GameObject canISpawnHere;
    [SerializeField] int randomEnemySpawn;
    [SerializeField]private int bossMaxHP = 50;
    public int bossHP;
   // The type of boss FSM that allows the boss to change there tempo mid fight 
    public enum TypeOfBossBPM { Slow, Normal, Fast, Intense, Chaotic };
    [SerializeField] TypeOfBossBPM bossPreferredBPM;


    private void Start()
    {
        bossHP = bossMaxHP;

    }

    private void Update()
    {
       
    }



    //Checks the boss tempo to see what speed it should be summoning minions 
    public void BossBPM(int bossbpm)
    {
        switch (bossbpm)
        {
            case 0:


                //Turns the track to a SlowBPMSong


             break;


            case 1:

                //Turns the track to a Normal BPM


             break;

            case 2:

                //Turns The track to a Fast Bpm

             break;

            case 3:

                //Turns the track to a Intense BPM

             break;

            case 4:

                //Turns the track to a Chaotic BPM
            
             break;


        }



    }

   //A function list that chains that allows me to use the audioController to control the speed the fuctions are use at
   public void RandomMinionToSpawn()
    {
        //Makes a random that checks the minions to spawn
       randomEnemySpawn = Random.Range(0,minionsToSpawn.Length);
        changeSpawnPoint();
    }

    public void changeSpawnPoint()
    {
        //Checks the spawn area that allows the minions to spawn
        canISpawnHere = GameManager.instance.spawnablePlace[Random.Range(0, GameManager.instance.spawnablePlace.Count)];

        if (canISpawnHere.gameObject.GetComponent<minionSpawnPlace>().isSpawnable)
        {
            SpawnRandomEneimes();
        }
        else
        {
            Debug.Log("Can't spawn here");
            
        }
       
        
    }
    
    public void SpawnRandomEneimes()
    {
        //Use Game Manager to spawn minions on points 
        Instantiate(minionsToSpawn[randomEnemySpawn],canISpawnHere.gameObject.transform);
    }


}
