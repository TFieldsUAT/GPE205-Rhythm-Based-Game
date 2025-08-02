using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] Transform bossPOS;
    [SerializeField] GameObject bossSpawn;
    [SerializeField] Transform leveltileSpawn;
    public GameObject playerSpawnPosition;
    public int randomSpawnPlace;
    [SerializeField] GameObject tempWeapon;
    [SerializeField] GameObject xrPlayer;


    [Header("TileMap")]
    [SerializeField] int tileX;
    [SerializeField] int tileY;
    [SerializeField] int tileTotal;
    [SerializeField] int gridSpacing = 1;



    public int foundPTargetName = 0;
    public int foundETargetName = 0;
    private int randomBossSpawned;
    private float levelTiles;

    public bool spawnBossEnemy;

    public bool battleStart;


    [Header("Enemies that can Spawn")]

    [SerializeField] List<GameObject> spawnableBosses;


    [Header ("Player And Spawnable Places")]
    public List<GameObject> actors;
    public List<GameObject> spawnablePlace;
    public List <Vector3> groundTiles;

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
        tileTotal = tileX * tileY;
        LevelTileSpawner();
        CreatePlayer();

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
           // SpawnBigBoss();

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




    private void LevelTileSpawner()
    {
        // Gets and creates A pos For the player to be spawned on 
        for (int i = 0; levelTiles < tileTotal; i++)
        {

           /* if (i <= 3 && i >= 0)
            {
                //adds one to the spawner to bascially create another row when it hits a certain point 
                levelTiles++;
                Instantiate(leveltileSpawn);
                leveltileSpawn.transform.position = new Vector3(i, 0, 0);
                groundTiles.Add(leveltileSpawn.transform.position);

            }
            else if (i >= 3 && i <= 7)
            {

                levelTiles++;
                Instantiate(leveltileSpawn);
                leveltileSpawn.transform.position = new Vector3(i - 4, 0, -1);
                groundTiles.Add(leveltileSpawn.transform.position);
            }
            else if (i >= 7 && i <= 12)
            {

                levelTiles++;
                Instantiate(leveltileSpawn);
                leveltileSpawn.transform.position = new Vector3(i - 8, 0, -2);
                groundTiles.Add(leveltileSpawn.transform.position);
            }*/
           if(i < tileX)
            {
                levelTiles++;
                Instantiate(leveltileSpawn);
                leveltileSpawn.transform.position = new Vector3(i, 0, gridSpacing);
                groundTiles.Add(leveltileSpawn.GetChild(0).transform.position);


            }
            else if(i > tileX)
            {
                i = 0;
                levelTiles++;
                Instantiate(leveltileSpawn);
                leveltileSpawn.transform.position = new Vector3(i, 0, gridSpacing--);
                groundTiles.Add(leveltileSpawn.GetChild(0).transform.position);
            }


            else
            {
                Debug.Log("Code error");
            }
        }

    }



    //spwans The big boss In a Area
    /* public void SpawnBigBoss()
     {
         spawnBossEnemy = true;
         randomBossSpawned = Random.Range(0, spawnableBosses.Count);
        bossSpawn = Instantiate(spawnableBosses[randomBossSpawned],bossPOS);



     }*/


    //damgages The the boss
    /*public void DmgBoss(int dmgtoBoss)
    {
        bossSpawn.GetComponent<BossFSM>().bossHP -= dmgtoBoss;
        Debug.Log("Boss Has Taken:" + dmgtoBoss + " Boss Has: " + bossSpawn.GetComponent<BossFSM>().bossHP + "  Hp Left ");
    }*/


    // Damages the player


    private void CreatePlayer()
    {
        //Create player and set the players POS
        randomSpawnPlace = Random.Range(0, groundTiles.Count);
        //playerSpawn.position = playersSpawnPOS[randomSpawnPlace];

        Debug.Log("Random pos choosen was: " + randomSpawnPlace + groundTiles[randomSpawnPlace]);
        //Changes where the player Spawn



        //make player spawn
        playerSpawnPosition = Instantiate(xrPlayer);
        actors.Add(playerSpawnPosition);
        Instantiate(tempWeapon, playerSpawnPosition.transform);
        tempWeapon.transform.parent = null;

    }




    public void DmgtoPlayer(int dmgtoPlayer)
    {
        actors[0].GetComponent<PlayerStats>().pcurrentHP -= dmgtoPlayer;
        Debug.Log("Player Has Taken:" + dmgtoPlayer + " Player Has: " + actors[0].GetComponent<PlayerStats>().pcurrentHP + "  Hp Left ");
    }
   

}
