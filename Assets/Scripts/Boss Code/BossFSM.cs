using UnityEngine;
using UnityEngine.Audio;
using static MagicSO;

public class BossFSM : MonoBehaviour
{

    public AudioResource bossMusic;
    public int bossTechicallyBPM;
    [SerializeField]private int bossMaxHP = 50;
    public int bossHP;


    private void Start()
    {
        bossHP = bossMaxHP;
    }

    public enum TypeOfBossBPM { Slow, Normal, Fast, Intense, Chaotic };
    [SerializeField] TypeOfBossBPM bossPreferredBPM;























    public void BossBPM(int bossbpm)
    {
        switch (bossbpm)
        {
            case 0:


                //Turns the track to a SlowBPMSong


             break;


            case 1:

                //Turns the track to a Normal BPM


             break;

            case 2:

                //Turns The track to a Fast Bpm

             break;

            case 3:

                //Turns the track to a Intense BPM

             break;

            case 4:

                //Turns the track to a Chaotic BPM
            
             break;


        }



    }

   
   
    



}
