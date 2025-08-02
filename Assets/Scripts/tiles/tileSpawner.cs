using System.Collections.Generic;
using UnityEngine;

public class tileSpawner : MonoBehaviour
{
   [SerializeField] Transform spawnArea;
   [SerializeField] List<GameObject> typeOfSpawns;
    [SerializeField] GameObject spawnObject;
    [SerializeField] int randomSpawner;
    public bool canISpawnSomething;


    void Start()
    {
        canISpawnSomething = true;
        randomSpawner = Random.Range(0, typeOfSpawns.Count);


        if (typeOfSpawns[randomSpawner].gameObject != null && canISpawnSomething == true)
        {
           spawnObject = Instantiate(typeOfSpawns[randomSpawner], spawnArea);
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

}
