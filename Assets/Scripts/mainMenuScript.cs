using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class mainMenuScript : MonoBehaviour
{
   public GameObject playerSpawnArea;
    [SerializeField] Slider VolumeSlider;
    [SerializeField] GameObject enemiesThatWereDefeated;




    public void BattleButton()
    {
        GameManager.instance.BattleBegin();


    }

    public void ChangeSong()
    {
        GameManager.instance.musicMaker.GetComponent<MusicController>().ChangeTrack();

    }

    public void ChangeVolume()
    {
        GameManager.instance.musicMaker.GetComponent<AudioSource>().volume = VolumeSlider.value;
    }

    public void QuitGame()
    {
        //Only Works in not full build
        Application.Quit();
    }

    private void Update()
    {
        enemiesThatWereDefeated.GetComponent<TextMeshProUGUI>().text = GameManager.instance.enemiesDefeated.ToString();
    }
}
