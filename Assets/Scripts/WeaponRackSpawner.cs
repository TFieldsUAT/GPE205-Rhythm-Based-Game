using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class WeaponRackSpawner : MonoBehaviour
{

    [SerializeField] GameObject[] weaponSpawner;
    public List<GameObject> weaponsToSpawn;
    [SerializeField] GameObject weaponSpawned;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        for (int i = 0; i < weaponSpawner.Length; i++)
        {
          Instantiate(weaponsToSpawn[i], weaponSpawner[i].transform,false);
           // weaponsToSpawn[i].transform.parent = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
