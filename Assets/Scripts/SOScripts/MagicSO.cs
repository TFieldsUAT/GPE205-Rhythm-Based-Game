using UnityEngine;
using UnityEngine.Events;


[CreateAssetMenu(fileName = "Magic", menuName = "AFP/newMagic")]
public class MagicSO : ScriptableObject
{
       //This Creates A list of different Aspects The Magic can have
        public enum mainMagic { Fire, Water, Ice, Earth, Lighting, Pressure, Light, Dark, Poison, Void, Smn, Hysteria };
        enum magicMastery { fractured, incomplete, basic, advanced, mastered };

        [Header("Magic Name,Magic Type and Mastery Level")]
        public string MagicName;
        public mainMagic magicSource;
        [SerializeField] magicMastery magicMasteryLevel;
        //[SerializeField] bool testBool;
        //[SerializeField] int testNumber = 6;

        private void OnValidate()
        {
            // StatusEffect(testBool,testNumber);
        }


        public bool StatusEffect(bool statuesEffectIsTrue, int StatNumbers)
        {

            switch ((int)magicMasteryLevel)
            {
                case 0:
                    statuesEffectIsTrue = Random.Range(0, 100) <= 15f + StatNumbers;
                    break;

                case 1:
                    statuesEffectIsTrue = Random.Range(0, 100) <= 25f + StatNumbers;
                    break;

                case 2:
                    statuesEffectIsTrue = Random.Range(0, 100) <= 35f + StatNumbers;
                    break;

                case 3:
                    statuesEffectIsTrue = Random.Range(0, 100) <= 45f + StatNumbers;
                    break;

                case 4:
                    statuesEffectIsTrue = Random.Range(0, 100) <= 55f + StatNumbers;
                    break;


            }

            Debug.Log(statuesEffectIsTrue);

            return statuesEffectIsTrue;
        }

    

}