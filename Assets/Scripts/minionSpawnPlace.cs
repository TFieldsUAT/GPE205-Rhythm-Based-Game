using UnityEngine;

public class minionSpawnPlace : MonoBehaviour
{
   [SerializeField] private Transform minSpawnPlace;
    [SerializeField] private MinionFSM minionDetector;
    [SerializeField] float downTime;
    public bool isSpawnable;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isSpawnable = true;
        minSpawnPlace = GetComponent<Transform>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        //Checks to see if there is a minion in the spawn area. If so don't added another minion
        minionDetector = minSpawnPlace.GetComponentInChildren<MinionFSM>();
        downTime -= Time.deltaTime;
        if (minionDetector != null && downTime >= 0)
        {
         
            isSpawnable = false;
        }
        else if (minionDetector == null && downTime < 0)
        {
            downTime = Random.Range(4, 15);
            isSpawnable = true;
        }

        
    }


    public void MinionHere()
    {

        if (!isSpawnable)
        {
            Debug.Log("Not able to spawn a Minion");
        }
         else if(isSpawnable)
        {
            Debug.Log("Minion Spawnable");
        }


    }


}
