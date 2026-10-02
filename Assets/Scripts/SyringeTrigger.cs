using UnityEngine;

public class SyringeTrigger : MonoBehaviour
{
    [Header("Animator")]
    public Animator targetAnimator;

    [Header("Object Tag")]
    public string syringeTag = "Sirnge";

    [Header("UI")]
    public GameObject Ui5;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag(syringeTag))
            return;

        Debug.Log("Syringe Entered Trigger");

        if (targetAnimator != null)
        {
            // Trigger OUT animation
            targetAnimator.SetTrigger("Out");
        }
        else
        {
            Debug.LogError("Target Animator is not assigned!");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Sirnge"))
        {
            Ui5.SetActive(true);
        }
    }
}