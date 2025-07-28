using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] Transform bossPOS;

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
                                                            actors.Add(other.gameObject);
                                                            Debug.Log("added to list");
                                                        }
                                                        else if (other.gameObject.layer == 18 && actors.Count > 0)
                                                        {
                                                            for (int i = 0; i < actors.Count; i++)
                                                            {
                                                                if (other.gameObject.name == actors[i].gameObject.name)
                                                                {
                                                                    Debug.Log("Already in list");
                                                                    foundPTargetName++;
                                                                }
                                                                else if (other.gameObject.name != actors[i].gameObject.name)
                                                                {
                                                                    Debug.Log("Not in list");
                                                                }
                                                            }

                                                            if (foundPTargetName == 0)
                                                            {
                                                                actors.Add(other.gameObject);
                                                            }
                                                            else
                                                            {
                                                                Debug.Log("Nothing added to list");
                                                            }

                                                        }
                                                        //Finding Enemies And spawn list then Sorting them on the list
                                                        else if (other.gameObject.layer == 20 && spawnablePlace.Count == 0)
                                                        {
                                                            spawnablePlace.Add(other.gameObject);
                                                            Debug.Log("added to list");

                                                        }
                                                        else if (other.gameObject.layer == 20 && spawnablePlace.Count >= 1 && foundETargetName < 10)
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




    public void SpawnBigBoss()
    {
        spawnBossEnemy = true;
        randomBossSpawned = Random.Range(0, spawnableBosses.Count);
        Instantiate(spawnableBosses[randomBossSpawned],bossPOS);



    }



   

}
