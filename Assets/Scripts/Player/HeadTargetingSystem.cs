using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HeadTargetingSystem : MonoBehaviour
{
    [SerializeField] LayerMask targetingMask;
    [SerializeField] float headTargetingDis = 1000f;
    [SerializeField] RaycastHit headTargeting;
    public Transform targetHitTransform;
    public List<Transform> multiTargetTransform;
    [SerializeField] InputActionReference B_button;
    [SerializeField] InputActionReference A_button;
    [SerializeField] InputActionReference Y_button;
    [SerializeField] InputActionReference X_button;
    [SerializeField] Transform vrCamera;
    [SerializeField] int foundTargetName;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (A_button.action.WasPressedThisFrame())
        {
            Debug.Log("A was pressed");
            GetComponent<PlayerStats>().ActiveDisplay();
        }

        if (Y_button.action.WasPressedThisFrame())
        {
            Debug.Log("Y was pressed");
            GetComponent<PlayerStats>().SelectedWeapon();
        }


        // this is for combat when its added
        if (B_button.action.WasPressedThisFrame())
        {
            Debug.Log("B was pressed");
        }
        //Checks to see if the raycast hit anything 
        if (Physics.Raycast(vrCamera.position, vrCamera.forward, out headTargeting, headTargetingDis, targetingMask, QueryTriggerInteraction.UseGlobal))
        {
                Debug.Log("Hit target");
                targetHitTransform = headTargeting.transform;
                targetHitTransform.GetChild(0).gameObject.SetActive(true);

                //Saves the enemy for later attacks in battle mode 
                if (B_button.action.WasPressedThisFrame() && targetHitTransform)
                {
                    foundTargetName = 0;
                    if (multiTargetTransform.Count > 0)
                    {
                        //adds a enemy to array 
                        for (int i = 0; i < multiTargetTransform.Count; i++)
                        {
                            if (targetHitTransform.gameObject.name == multiTargetTransform[i].gameObject.name)
                            {
                                Debug.Log("Already in list");
                                foundTargetName++;
                            }
                            else if (targetHitTransform.gameObject.name != multiTargetTransform[i].gameObject.name)
                            {
                                Debug.Log("Not in list");
                            }
                        }

                        if (foundTargetName == 0)
                        {
                            multiTargetTransform.Add(targetHitTransform.transform);
                        }
                        else
                        {
                            Debug.Log("Nothing added to list");
                        }

                    }
                    else if (multiTargetTransform.Count == 0)
                    {
                        multiTargetTransform.Add(targetHitTransform.transform);
                    }
                    //Move to target later code
                }
        }
        else
        {

            if (targetHitTransform != null)
            {
                targetHitTransform.GetChild(0).gameObject.SetActive(false);
                targetHitTransform = null;
            }
            Debug.Log("Hit nothing");
        }

        Debug.DrawRay(vrCamera.position, vrCamera.forward, Color.green);
    }

    //Clears the array or enemy target list
    public void DumpTargetList()
    {
        multiTargetTransform.Clear();
    }

}