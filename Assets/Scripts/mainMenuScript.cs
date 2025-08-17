using UnityEngine;

public class mainMenuScript : MonoBehaviour
{
   public GameObject playerSpawnArea;






    public void ButtonWasPressed()
    {
        GameManager.instance.BattleBegin();


    }
}
