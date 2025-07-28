using Unity.VisualScripting;
using UnityEngine;

public class TestBeatEvent : MonoBehaviour
{
    [SerializeField] private Transform boxTransform;



    private void Start()
    {
        boxTransform = GetComponentInChildren<Transform>();
    }


    public void Showbox()
    {
        if (boxTransform.gameObject.activeInHierarchy == true)
        {

            boxTransform.gameObject.SetActive(false);
        }
        else if(boxTransform.gameObject.activeInHierarchy == false)
        {
            boxTransform.gameObject.SetActive(true);
        
        }
    }
}
