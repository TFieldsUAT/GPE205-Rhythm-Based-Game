using System.Collections.Generic;
using UnityEngine;

public class tileSpawner : MonoBehaviour
{
   [SerializeField] Transform spawnArea;
   [SerializeField] List<GameObject> typeOfSpawns;
    [SerializeField] LayerMask groundLayer;
    public GameObject spawnObject;
    [SerializeField] GameObject blockers;
    [SerializeField] int randomSpawner;
    [SerializeField] int randomNumberForEnemy;
   [SerializeField] GameObject[] enemySpawn;
    [SerializeField]  List<Vector3> areaToSpawnBlockers;

    [SerializeField] List<GameObject> blockersSpawned;
    [SerializeField]  int spawnBlocker;
    public bool canISpawnSomething;



    [SerializeField] RaycastHit leftRay;
    [SerializeField] RaycastHit rightRay;
    [SerializeField] RaycastHit forwardRay;
    [SerializeField] RaycastHit backRay;


    [SerializeField] GameObject lRayHit;
    [SerializeField] GameObject rRayHit;
    [SerializeField] GameObject fRayHit;
    [SerializeField] GameObject bRayHit;


    [SerializeField] bool lHit;
    [SerializeField] bool rHit;
    [SerializeField] bool fHit;
    [SerializeField] bool bHit;

    void Start()
    {
        canISpawnSomething = true;
        randomSpawner = Random.Range(0, typeOfSpawns.Count);

        //Changes what is on top of the tile itself.
        if (typeOfSpawns[randomSpawner].gameObject != null && canISpawnSomething == true)
        {
           spawnObject = Instantiate(typeOfSpawns[randomSpawner], spawnArea);
            canISpawnSomething = false;
        }
        else
        {
            return;
        }

      




    }



    // Update is called once per frame
    void Update()
    {


       


    }

    public void DestroySpawnObject()
    {

        Destroy(spawnObject);
    }

    public void SeeWhatsAroundMe()
    {
        //Checks all areas to see if the board has anything around it basically checks Left right Forward And Back.
        if (Physics.Raycast(transform.position,-transform.right, out leftRay, 300f, groundLayer, QueryTriggerInteraction.UseGlobal))
        {
            lRayHit = leftRay.transform.gameObject;
            Debug.Log("There Is A Ground Left Of me");
            lHit = true;
        }
            else
            {
            lHit = false;
            }
        
        if (Physics.Raycast(transform.position, transform.right, out  rightRay, 300f, groundLayer, QueryTriggerInteraction.UseGlobal))
        {
                    rRayHit = rightRay.transform.gameObject;
                Debug.Log("There Is A Ground Right Of me");
           rHit = true;
        }
           else
            {
            rHit = false;
           
            }

        if (Physics.Raycast(transform.position,transform.forward, out  forwardRay, 300f, groundLayer, QueryTriggerInteraction.UseGlobal))
        {    
            fRayHit = forwardRay.transform.gameObject;
            fHit = true;
                Debug.Log("There Is A Ground Forward Of me");
        }
            else
            {
            fHit = false;
            
            }

        if (Physics.Raycast(transform.position, -transform.forward, out  backRay, 300f, groundLayer, QueryTriggerInteraction.UseGlobal))
        {
            bHit = true;
               bRayHit = backRay.transform.gameObject;
                Debug.Log("There Is A Ground back Of me");
        
        }
            else
            {
            bHit= false;
            }

        Debug.DrawRay(transform.position, -transform.right, Color.green);
        Debug.DrawRay(transform.position, transform.right, Color.blue);
        Debug.DrawRay(transform.position, transform.forward, Color.red);
        Debug.DrawRay(transform.position, -transform.forward, Color.yellow);

        CreateBounds();
       
        
    }



    private void CreateBounds()
    {

        if (!lHit)
        {
          blockersSpawned.Add(Instantiate(blockers));
            blockers.transform.position = gameObject.transform.position + Vector3.left;
            Debug.Log("Nothing Is left of me");
           blockers.GetComponentInChildren<Transform>().transform.LookAt(GameManager.instance.actors[0].transform.position);
            
        }
         if (!rHit)
        {
            Debug.Log("Nothing Is Right of me");
            blockersSpawned.Add(Instantiate(blockers));
            blockers.transform.position = gameObject.transform.position + Vector3.right;
            blockers.GetComponentInChildren<Transform>().transform.LookAt(GameManager.instance.actors[0].transform.position);
       
        }
         if(!fHit)
        {
            blockersSpawned.Add(Instantiate(blockers));
            blockers.transform.position = gameObject.transform.position + Vector3.forward;
            Debug.Log("Nothing Is forward of me");
            blockers.GetComponentInChildren<Transform>().transform.LookAt(GameManager.instance.actors[0].transform.position);
            
        }
         if (!bHit)
        {
            blockersSpawned.Add(Instantiate(blockers));
            blockers.transform.position = gameObject.transform.position + Vector3.back;
            Debug.Log("Nothing Is Back of me");
           blockers.GetComponentInChildren<Transform>().transform.LookAt(GameManager.instance.actors[0].transform.position);
            
        }


    }

    public void DestroyBlockers()
    {
      for (int i = 0; i < blockersSpawned.Count; ++i)
        {
            Destroy(blockersSpawned[i]);
        }

    }


    public void spawnEnemy()
    {
        randomNumberForEnemy = Random.Range(0, enemySpawn.Length);
        spawnObject = Instantiate(enemySpawn[randomNumberForEnemy], spawnArea);


    }
}
