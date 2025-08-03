using UnityEngine;

public class Gem : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    


    public void StatUp()
    {
        GameManager.instance.actors[0].GetComponent<PlayerStats>().pSTR += 5;
        Destroy(gameObject);
    }

}
