using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class MinionFSM : MonoBehaviour
{

    public string minionNane;
    public GameObject enemiesTarget;
    public float timeForMovement = 10;
    public float maxMovement;
    public float speedOfMovement = 1f;
    public int minionHp;
    public int minionMaxHP;
    public float minionAttack;
    public int dmgAmount;
    [SerializeField] int randomRoamSpot;
    public GameObject emotionText;
    [SerializeField] Vector3 randomEnemyPOI;
    //Checks to see a few var with minions 

    [SerializeField] bool attackingPlayer;
    [SerializeField] bool willMinionAttack;
    [SerializeField] MagicSO[] minionsMagic;
    [SerializeField] float timeTillDestroyed = 30;
    

    // made a enum that allows me to set the minions FSM
    public enum minionsEmotionState { Scared,Aggressive,Happy,Cocky,Determind,Confused,desperate,NonLiving};
   
    [Header("Reaction for The minions Who spawns")]
    [SerializeField] minionsEmotionState minionsEmotionalState;


    //Minions when first created changes states, This is temp for when i change the spawners 
    private void Awake()
    {
       
        gameObject.transform.SetParent(null);
        minionsEmotionalState = minionsEmotionState.Scared+Random.Range(0,7);
        //Debug.Log(minionsEmotionalState);
    }
    //allows the switch states machine to work
    private void Start()
    {
        FreeRoam();
        emotionText.GetComponent<TextMeshProUGUI>().text = minionsEmotionalState.ToString();
        //Debug.Log(emotionText.GetComponent<TextMeshProUGUI>().text);
       MinionReactions((int)minionsEmotionalState);
        enemiesTarget = GameManager.instance.actors[0];
        minionMaxHP = minionHp;
    }
    //count down minions time to get destroyed
    private void Update()
    {

        if (GameManager.instance.playerLost)
        {
            MinionSelfDestruct();
            Destroy(gameObject);
        }

        timeForMovement -= Time.deltaTime;

        if (timeForMovement < 0)
        {
            SwitchMinionsBehavior();
            EnemyMoveTowards();
        }



        if(timeTillDestroyed < 0 || minionHp < 0)
        {
            MinionDestroyed();
        }

        if(willMinionAttack)
        {
            gameObject.transform.LookAt(enemiesTarget.transform);
        }
        else if(!willMinionAttack)
        {
            gameObject.transform.LookAt(randomEnemyPOI);
        }
        
    }


    // Sets different stats for minions based on there Current State  
    public void MinionReactions(int reaction)
    {
        switch (reaction)
        {
            case 0:


                //Scared reaction
                minionHp = Random.Range(1, 6)*GameManager.instance.levelInPlay;
                Scared();
             

                break;


            case 1:
                minionHp = Random.Range(1, 3) * GameManager.instance.levelInPlay;
                //Aggressive Reaction
                Aggresive();

                break;

            case 2:
                minionHp = Random.Range(3, 8) * GameManager.instance.levelInPlay;
                //Happy Reaction
                Happy();
                break;

            case 3:
                minionHp = Random.Range(1, 3) * GameManager.instance.levelInPlay;
                //Cocky Reaction
                Cocky();
                break;

            case 4:
                minionHp = Random.Range(7, 13) * GameManager.instance.levelInPlay;
                //Determined Reaction
                Detemind();
                break;
            
             case 5:
                minionHp = Random.Range(1, 6) * GameManager.instance.levelInPlay;
                //Confused reaction
                Confused();
                break;

             case 6:
                minionHp = Random.Range(1, 19) * GameManager.instance.levelInPlay;
                //desperate reaction
                Desperate();

                break;

             case 7:
                minionHp = 1;
                //NonLiving reaction
                NonLiving();
             break;  


        }
      


    }


    // Different Stats that Minions can Have Based on states
    public void Scared()
    { 
        
       maxMovement =+ Random.Range(0, 20);
        willMinionAttack = false;
    }

    public void Aggresive()
    {

        maxMovement = +Random.Range(1, 7);
        willMinionAttack = true;
      
    }


    public void Happy()
    {
        maxMovement = +Random.Range(5, 20);
        willMinionAttack = false;
        
    }


    public void Cocky()
    {
        maxMovement = +Random.Range(12, 40);
        willMinionAttack = false;
    }


    public void Detemind()
    {
        maxMovement = +Random.Range(2, 10);
        willMinionAttack = true;
       

    }

    public void Confused()
    {
        maxMovement = +Random.Range(9, 34);
        willMinionAttack = false;
    }


    public void Desperate()
    {
        maxMovement = +Random.Range(2, 10);
        willMinionAttack = true;
       
    }


    public void NonLiving()
    {
        maxMovement = +Random.Range(18, 60);
        willMinionAttack = true;
    }



    private void EnemyMoveTowards()
    {
        

       if(transform.position != enemiesTarget.transform.position && willMinionAttack && !attackingPlayer)
        {
            transform.position = Vector3.MoveTowards(transform.position, enemiesTarget.transform.position, speedOfMovement);
            timeForMovement = maxMovement;
        }
       else if(attackingPlayer)
        {
            dmgAmount = (int)minionAttack + Random.Range(0, 3);
            //Player Takes Dmg
            GameManager.instance.DmgtoPlayer(dmgAmount);
            timeForMovement = maxMovement;
        }
       // Makes The enemy go to points it sets up on the map
        else if(!willMinionAttack && transform.position != randomEnemyPOI)
        {
        
            transform.position = Vector3.MoveTowards(transform.position, randomEnemyPOI, speedOfMovement);
           
            timeForMovement = maxMovement;


        }else if(!willMinionAttack && transform.position == randomEnemyPOI)
        {
            FreeRoam();

        }
      

    }    


    private void FreeRoam()
    {
     randomRoamSpot =  Random.Range(0, GameManager.instance.groundTiles.Count);
     randomEnemyPOI = GameManager.instance.groundTiles[randomRoamSpot];
    

    }



    // this code is called once the minions Time runs out or is killed
    public void MinionDestroyed()
    {
    
        if (timeTillDestroyed >= 0 && minionHp <=0)
        {
            Debug.Log("Minion has been defeated");
            for( int i=0; i < GameManager.instance.spawnEnemies.Count; i++)
            {
                if(gameObject.transform == GameManager.instance.spawnEnemies[i].transform)
                {
                    GameManager.instance.enemiesDefeated++;
                    GameManager.instance.spawnEnemies.Remove(GameManager.instance.spawnEnemies[i]);
                    Destroy(gameObject); return;
                }
            }


           
          
        }
    }



    public void MinionSelfDestruct()
    {
        for (int i = 0; i < GameManager.instance.spawnEnemies.Count; i++)
        {
            if (gameObject.transform == GameManager.instance.spawnEnemies[i].transform)
            {
               
                GameManager.instance.spawnEnemies.Remove(GameManager.instance.spawnEnemies[i]);
                Destroy(gameObject); return;
            }
        }
    }


    public void SwitchMinionsBehavior()
    {
        if(minionHp < minionMaxHP)
        {
            
            willMinionAttack = true;
        }
        willMinionAttack = true;

    }



    public void DmgMinion(int Dmgs)
    {

        minionHp -= Dmgs;
    }



    public void GettingReadyToAttack()
    {
        if(willMinionAttack) {
            attackingPlayer = true;
        }

    }

    public void FindingPlayer()
    {
        if (willMinionAttack)
        {
            attackingPlayer = false;
        }

    }

}
