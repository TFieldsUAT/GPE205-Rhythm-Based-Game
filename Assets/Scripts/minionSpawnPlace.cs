using UnityEngine;

public class minionSpawnPlace : MonoBehaviour
{
   [SerializeField] private Transform minSpawnPlace;
    public bool isSpawnable;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        minSpawnPlace = GetComponent<Transform>().transform;
    }

    // Update is called once per frame
    void Update()
    {



        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == 19)
        {
            isSpawnable = false;
        }
        
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 19)
        {
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
