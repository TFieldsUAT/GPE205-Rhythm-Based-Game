using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] Transform bossPOS;
    [SerializeField] GameObject bossSpawn;

    public int foundPTargetName = 0;
    public int foundETargetName = 0;
    private int randomBossSpawned;


    public bool spawnBossEnemy;

    public bool battleStart;


    [Header("Enemies that can Spawn")]

    [SerializeField] List<GameObject> spawnableBosses;


    [Header ("Player And Spawnable Places")]
    public List<GameObject> actors;
    public List<GameObject> spawnablePlace;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

            //Makes it so unity doesn't Destory this on loading new level.
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            //If game manager exist It will destory it. If its not itself
            Destroy(gameObject);
        }
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        battleStart = true;
    }

    // Update is called once per frame
    void Update()
    {
     
        if(battleStart == true)
        {

        }

    }




    private void OnTriggerStay(Collider other)
    {

        if (other.gameObject.layer == 21 && spawnBossEnemy == false)
        {
            bossPOS = other.transform;
            SpawnBigBoss();

        }
        else if(spawnBossEnemy == true)
        { 

           //Finding Player and Sorting them for multiplayer 
            if (other.gameObject.layer == 18 && actors.Count == 0)
            {
                //if Layer Is Correct And Actor in list is zero Add Actor.
             actors.Add(other.gameObject);
             Debug.Log("added to list");
             }
                else if (other.gameObject.layer == 18 && actors.Count <= 0)
                 {
                //Checks to see if any actor that was added is the same as any other actor bascially stopping actors from being added twice
                  for (int i = 0; i < actors.Count; i++)
                   {
                    //
                     if (other.gameObject.name == actors[i].gameObject.name && actors.Count <= 0)
                     {
                      Debug.Log("Already in list");
                      foundPTargetName++;
                      return;
                     }
                       else if (other.gameObject.name != actors[i].gameObject.name)
                       {
                       Debug.Log("Not in list"); 
                       return;
                       }
                   }
                  // If no actor added add actor
                  if (foundPTargetName == 0)
                   {
                   actors.Add(other.gameObject);
                   return;         
                   }
                   else
                    {
                     Debug.Log("Nothing added to list");                          
                    return;
                   }

                }
                          //Finding Enemies And spawn list then Sorting them on the list
                else   if (other.gameObject.layer == 20 && spawnablePlace.Count == 0)
                           {
                //adds a space for spawning in the game for minions 
                            spawnablePlace.Add(other.gameObject);
                            Debug.Log("added to list");

                           }
            // Checks to see if spawn spot has beed added to array or not More of less the code added above
                             else if (other.gameObject.layer == 20 && spawnablePlace.Count > 0 && foundETargetName < spawnablePlace.Count + 6)
                             {
                               for (int i = 0; i < spawnablePlace.Count; i++)
                               {
                                if (other.gameObject.name == spawnablePlace[i].gameObject.name)
                                {
                                 Debug.Log("Already in list");
                                 foundETargetName++;
                                }
                                 else if (other.gameObject.name != spawnablePlace[i].gameObject.name)
                                 {
                                Debug.Log("Not in list");
                                 }
                               }

                                if (foundETargetName == 0)
                                {
                                spawnablePlace.Add(other.gameObject);

                                }
                                else
                                {
                                 Debug.Log("Nothing added to list");

                                }

                             }

        }


    }



    //spwans The big boss In a Area
    public void SpawnBigBoss()
    {
        spawnBossEnemy = true;
        randomBossSpawned = Random.Range(0, spawnableBosses.Count);
       bossSpawn = Instantiate(spawnableBosses[randomBossSpawned],bossPOS);
        


    }


    //damgages The the boss
    public void DmgBoss(int dmgtoBoss)
    {
        bossSpawn.GetComponent<BossFSM>().bossHP -= dmgtoBoss;
        Debug.Log("Boss Has Taken:" + dmgtoBoss + " Boss Has: " + bossSpawn.GetComponent<BossFSM>().bossHP + "  Hp Left ");
    }
    // Damages the player
    public void DmgtoPlayer(int dmgtoPlayer)
    {
        actors[0].GetComponent<PlayerStats>().pcurrentHP -= dmgtoPlayer;
        Debug.Log("Player Has Taken:" + dmgtoPlayer + " Player Has: " + actors[0].GetComponent<PlayerStats>().pcurrentHP + "  Hp Left ");
    }
   

}
