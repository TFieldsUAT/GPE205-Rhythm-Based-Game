using Unity.VisualScripting;
using UnityEngine;

public class MinionFSM : MonoBehaviour
{
    public string minionNane;
    public int minionHp;
    public float minionAttack;
    public int dmgAmount;

    [SerializeField] bool willMinionAttack;
    [SerializeField] MagicSO[] minionsMagic;
    [SerializeField] float timeTillDestroyed = 10;
    
    public enum minionsEmotionState { Scared,Aggressive,Happy,Cocky,Determind,Confused,desperate,NonLiving};
   
    [Header("Reaction for The minions Who spawns")]
    [SerializeField] minionsEmotionState minionsEmotionalState;



    private void Awake()
    {
        minionsEmotionalState = minionsEmotionState.Scared+Random.Range(0,7);
        Debug.Log(minionsEmotionalState);
    }

    private void Start()
    {
       MinionReactions((int)minionsEmotionalState);
    }

    private void Update()
    {
        timeTillDestroyed -= Time.deltaTime;
        if(timeTillDestroyed < 0 || minionHp < 0)
        {
            MinionDestroyed();
        }
    }



    public void MinionReactions(int reaction)
    {
        switch (reaction)
        {
            case 0:


                //Scared reaction
                minionHp = Random.Range(1, 6);
                Scared();
             

                break;


            case 1:
                minionHp = Random.Range(1, 3);
                //Aggressive Reaction
                Aggresive();

                break;

            case 2:
                minionHp = Random.Range(3, 8);
                //Happy Reaction
                Happy();
                break;

            case 3:
                minionHp = Random.Range(1, 3);
                //Cocky Reaction
                Cocky();
                break;

            case 4:
                minionHp = Random.Range(7, 13);
                //Determined Reaction
                Detemind();
                break;
            
             case 5:
                minionHp = Random.Range(1, 6);
                //Confused reaction
                Confused();
                break;

             case 6:
                minionHp = Random.Range(1, 19);
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



    public void Scared()
    { 
        
        timeTillDestroyed =+ Random.Range(0, 20);
        willMinionAttack = false;
    }

    public void Aggresive()
    {
        timeTillDestroyed = +Random.Range(1, 7);
        willMinionAttack = true;
    }


    public void Happy()
    {
        timeTillDestroyed = +Random.Range(5, 20);
        willMinionAttack = true;
    }


    public void Cocky()
    {
        timeTillDestroyed = +Random.Range(12, 40);
        willMinionAttack = false;
    }


    public void Detemind()
    {
        timeTillDestroyed = +Random.Range(2, 10);
        willMinionAttack = true;

    }

    public void Confused()
    {
        timeTillDestroyed = +Random.Range(9, 34);
        willMinionAttack = false;
    }


    public void Desperate()
    {
        timeTillDestroyed = +Random.Range(2, 10);
        willMinionAttack = true;
    }


    public void NonLiving()
    {
        timeTillDestroyed = +Random.Range(18, 60);
        willMinionAttack = true;
    }



    public void MinionDestroyed()
    {
        if (willMinionAttack == false)
        {
            dmgAmount = (int)minionAttack + Random.Range(0, 3);
            //Boss Should take Dmg
            GameManager.instance.DmgBoss(dmgAmount);
            Destroy(gameObject); return;
           
        }
        else if (willMinionAttack == true)
        {
            dmgAmount = (int)minionAttack + Random.Range(0, 3);
            //Player Takes Dmg
            GameManager.instance.DmgtoPlayer(dmgAmount);
            Destroy(gameObject); return;
        }
        else if (timeTillDestroyed >= 0 && minionHp <=0)
        {
            dmgAmount = (int)timeTillDestroyed + (int)minionAttack + Random.Range(0, 3);
            GameManager.instance.DmgBoss(dmgAmount);
            Destroy(gameObject); return;
        }
    }

}
