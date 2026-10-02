using UnityEngine;

public class XRTriggerNPCAnimation : MonoBehaviour
{
    [Header("NPC Animator")]
    public Animator npcAnimator;

    [Header("Animator Trigger Names")]
    public string enterTrigger = "PlayAnimation";
    public string exitTrigger = "ExitAnimation";

    [Header("XR Player Tag")]
    public string playerTag = "Player";

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag(playerTag))
            return;

        Debug.Log("Player ENTER");

        if (npcAnimator != null)
        {
            // Remove Exit trigger if it is pending
            npcAnimator.ResetTrigger(exitTrigger);

            // Start Player Animation
            npcAnimator.SetTrigger(enterTrigger);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag(playerTag))
            return;

        Debug.Log("Player EXIT");

        if (npcAnimator != null)
        {
            // Remove Enter trigger if it is pending
            npcAnimator.ResetTrigger(enterTrigger);

            // Go to Idle
            npcAnimator.SetTrigger(exitTrigger);
        }
    }
}