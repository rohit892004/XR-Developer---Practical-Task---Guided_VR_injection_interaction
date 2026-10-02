using UnityEngine;
using UnityEngine.InputSystem; 

public class animatehandoninput : MonoBehaviour
{
    // creating variables
    public InputActionProperty triggerValue;
    public InputActionProperty gripValue;

    public Animator handAnimator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //setting refrence input for them
        float trigger = triggerValue.action.ReadValue<float>();
        float grip = gripValue.action.ReadValue<float>();

        handAnimator.SetFloat("Trigger" , trigger);
        handAnimator.SetFloat("Grip" , grip);

    }
}
