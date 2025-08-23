using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;

public class GameManager : MonoBehaviour
{
    [Header("PlayerSpawnHub")]
    [SerializeField] GameObject mainMenuArea;
    [SerializeField] public  GameObject mainMenuAreaTransform;


    [Header("Battle stuff")]
    public static GameManager instance;
    [SerializeField] Transform bossPOS;
    [SerializeField] GameObject bossSpawn;
    [SerializeField] GameObject leveltileSpawn;
    public GameObject playerSpawnPosition;
    public int randomSpawnPlace;
    public int randomTileSpawn;
    public int randomEnemyPlaceSpawner;



    [Header("Enemy Caculator")]
    public int levelInPlay = 1;
    public int enemiesDefeated;
    public int maxNumberOfEnemies;
    public int amountOfEnemies;
    public int loopBreaker = 0;


    [Header("Player Stuff")]
    [SerializeField] WeaponStats weaponsCode;
    [SerializeField] GameObject tempWeapon;
    [SerializeField] GameObject xrPlayer;
    [Header("TileMap")]
    [SerializeField] int tileX;
    [SerializeField] int tileY;
    [SerializeField] int tileTotal;
    [SerializeField] int gridSpacing = 1;



    public int foundPTargetName = 0;
    public int foundETargetName = 0;
    private float levelTiles;
    public bool playerLost;
    public bool spawnBossEnemy;

    public bool battleStart;


    [Header("Enemies that can Spawn")]

    public List<GameObject> spawnEnemies;


    [Header ("Player And Spawnable Places")]
    public List<GameObject> actors;
    public List<GameObject> spawnablePlace;
    public List<GameObject> typesOfTiles;
    public List <Vector3> groundTiles;
    public List <GameObject> setGround;


    [Header("Audio sources")]
    [SerializeField] GameObject musicController;
    public GameObject musicMaker;
    [SerializeField] private AudioSource audioSource;
    public List <AudioResource> audioSourcesToPlay;



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
       musicMaker = Instantiate(musicController);
        audioSource = GetComponent<AudioSource>();
        battleStart = false;

        CreateHub();
        

    }


   



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerSpawnPosition = Instantiate(xrPlayer);
        actors.Add(playerSpawnPosition);
        PlacePlayerAtHub();
        
    }

    // Update is called once per frame
    void Update()
    {
            if (battleStart == true && loopBreaker < 30)
            {
                SetEnemies();
            }
            else if (loopBreaker >= 30)
            {
                IsTheBattleOver();
            }
        
    }




    private void LevelTileSpawner()
    {

       
        // Gets and creates A pos For the player to be spawned on 
        for (int i = 0; levelTiles <= tileTotal; i++)
        {
            //Checks to see if the tiles are greater than the person tile count
           if(i < tileX)
            {
                randomTileSpawn = Random.Range(0, typesOfTiles.Count);
                leveltileSpawn = typesOfTiles[randomTileSpawn];
                levelTiles++;
           setGround.Add(Instantiate(leveltileSpawn));
             

                if (i == randomSpawnPlace)
                {
                    leveltileSpawn.GetComponent<tileSpawner>().DestroySpawnObject();
                }
                leveltileSpawn.transform.position = new Vector3(i, 0, gridSpacing);
                groundTiles.Add(leveltileSpawn.transform.GetChild(0).transform.position);
             

            }
            else if(i > tileX)
            {
                
                randomTileSpawn = Random.Range(0, typesOfTiles.Count);
                leveltileSpawn = typesOfTiles[randomTileSpawn];
                i = 0;
                levelTiles++;
                setGround.Add(Instantiate(leveltileSpawn));

                if (i == randomSpawnPlace)
                {
                    leveltileSpawn.GetComponent<tileSpawner>().DestroySpawnObject();
                }

                leveltileSpawn.transform.position = new Vector3(i, 0, gridSpacing--);
                groundTiles.Add(leveltileSpawn.transform.GetChild(0).transform.position);
             
            }

           

            else
            {
                Debug.Log("Code error");
            }
        }
       

    }



    private void CreatePlayer()
    {
        //Create player and set the players POS
        randomSpawnPlace = Random.Range(0, groundTiles.Count);
       

      
        //Changes where the player Spawn

        //Makes it so enemies can't spawn here.
        setGround[randomSpawnPlace].GetComponent<tileSpawner>().DestroySpawnObject();
        setGround[randomSpawnPlace].GetComponent<tileSpawner>().canISpawnSomething = false;



        playerSpawnPosition.transform.position = new Vector3( groundTiles[randomSpawnPlace].x, groundTiles[randomSpawnPlace].y+1, groundTiles[randomSpawnPlace].z);
        //make player spawn
       
        // Instantiate(tempWeapon, playerSpawnPosition.transform);



    }

    //Sets the bounds for around the player  basically checks the space around the player
    private void SetBound()
    {
        foreach(GameObject t in setGround)
        {
            
            t.GetComponent<tileSpawner>().SeeWhatsAroundMe();
        }
    }

    private void DestroyBlockersReset()
    {
        foreach (GameObject t in setGround)
        {
            t.GetComponent<tileSpawner>().DestroyBlockers();
        }
    }


    private void SetEnemies()
    {
  
            randomEnemyPlaceSpawner = Random.Range(0, setGround.Count);

            //Spawn a random enemy on the map
            if (setGround[randomEnemyPlaceSpawner].GetComponent<tileSpawner>().canISpawnSomething == true && amountOfEnemies <= maxNumberOfEnemies)
            {
            //Sets The enemy on a plane so the enemy can start attacking.
              setGround[randomEnemyPlaceSpawner].GetComponent<tileSpawner>().spawnEnemy();
              spawnEnemies.Add ( setGround[randomEnemyPlaceSpawner].GetComponent<tileSpawner>().spawnObject);
                amountOfEnemies++;
            Debug.Log(" Enemy spawn :" + randomEnemyPlaceSpawner);

            }
            else
            {
                Debug.Log("EnemyNotSpawn");
            //Makes Sure The enemy loop Stops happening
                loopBreaker++;
                return;
            }
        
    }


    private void IsTheBattleOver()
    {
        if (actors[0].GetComponent<PlayerStats>().pcurrentHP <= 0 && battleStart==true) 
        {
            audioSource.resource = audioSourcesToPlay[1];
            audioSource.Play();
            Debug.Log("Player Loses");
            playerLost = true;

            //Get rid of all minions on player death
            for(int i = 0;i < spawnEnemies.Count;i++)
            {
                spawnEnemies[i].GetComponent<MinionFSM>().MinionSelfDestruct();

            }

            Reset();
        }
        else if(spawnEnemies.Count == 0 && battleStart == true)
        {
         audioSource.resource = audioSourcesToPlay[0];
         audioSource.Play();
            Debug.Log("Player Leveled UP");
            playerSpawnPosition.GetComponent<PlayerStats>().LevelUp();
            levelInPlay++;
            Reset();
        }


    }



    //Damgaes The player
    public void DmgtoPlayer(int dmgtoPlayer)
    {
        actors[0].GetComponent<AudioSource>().Play();
        actors[0].GetComponent<PlayerStats>().pcurrentHP -= dmgtoPlayer;
        Debug.Log("Player Has Taken:" + dmgtoPlayer + " Player Has: " + actors[0].GetComponent<PlayerStats>().pcurrentHP + "  Hp Left ");
    }


   public void BattleBegin()
    {
        if(playerLost)
        {
            playerSpawnPosition.GetComponent<PlayerStats>().Reset();
            enemiesDefeated = 0;
            levelInPlay=1;
            playerLost = false;
        }
        HideHub();
        maxNumberOfEnemies = Random.Range(0, 4) + levelInPlay;
        tileTotal = Random.Range(tileX,tileX*levelInPlay) * Random.Range(tileY, tileY * levelInPlay);
        LevelTileSpawner();
        CreatePlayer();
        SetBound();
        loopBreaker = 0;
        battleStart = true;
    }




    private void CreateHub()
    {
       mainMenuAreaTransform = Instantiate(mainMenuArea);

    }


    private void PlacePlayerAtHub()
    {

        playerSpawnPosition.GetComponent<PlayerStats>().SpawnPlayerBackAtHub();      

    }



    private void ShowHub()
    {
        mainMenuAreaTransform.SetActive(true);

    }



    private void HideHub()
    {
        mainMenuAreaTransform.SetActive(false);

    }



    public void Reset()
    {
        DestroyBlockersReset();
        for (int i = 0; i < setGround.Count; i++)
        {
            Destroy(setGround[i]);
        }
        levelTiles = 0;
        loopBreaker = 0;
        amountOfEnemies = 0;
        groundTiles.Clear();
        setGround.Clear();
        spawnEnemies.Clear();
        ShowHub();
        PlacePlayerAtHub();
        
       
        battleStart = false;
    }


    public GameObject AddWeaponToPlayer(GameObject PlayerToAddWeapon)
    {
       
        for (int i = 0; i < actors.Count; i++)
        {
            Debug.Log(actors[i].GetComponent<PlayerStats>().weaponCalling);

            if (actors[i].GetComponent<PlayerStats>().weaponCalling == true)
            {
              PlayerToAddWeapon.GetComponent<WeaponStats>().playerToAddedWeaponTo = actors[i].GetComponent<PlayerStats>().playerWeapon;
            }
        }
         return PlayerToAddWeapon;

    }

}
