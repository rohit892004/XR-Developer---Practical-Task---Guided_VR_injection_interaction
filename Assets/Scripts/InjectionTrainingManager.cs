using UnityEngine;

public class InjectionTrainingManager : MonoBehaviour
{
    public static InjectionTrainingManager Instance;

    [Header("UI Step Panels")]
    public GameObject[] stepPanels;

    [Header("Voice")]
    public AudioSource voiceSource;
    public AudioClip[] stepVoiceClips;

    private int currentStep = 0;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        ShowStep(0);
    }

    public void ShowStep(int step)
    {
        if (step < 0 || step >= stepPanels.Length)
            return;

        // Hide all steps
        for (int i = 0; i < stepPanels.Length; i++)
        {
            if (stepPanels[i] != null)
                stepPanels[i].SetActive(false);
        }

        // Show selected step
        if (stepPanels[step] != null)
            stepPanels[step].SetActive(true);

        currentStep = step;

        // Play voice
        if (voiceSource != null &&
            stepVoiceClips != null &&
            step < stepVoiceClips.Length &&
            stepVoiceClips[step] != null)
        {
            voiceSource.Stop();
            voiceSource.PlayOneShot(stepVoiceClips[step]);
        }

        Debug.Log("Showing Step " + (step + 1));
    }

    public void CompleteStep1()
    {
        if (currentStep == 0)
            ShowStep(1);
    }

    public void CompleteStep2()
    {
        if (currentStep == 1)
            ShowStep(2);
    }

    public void CompleteStep3()
    {
        if (currentStep == 2)
            ShowStep(3);
    }

    public void CompleteStep4()
    {
        if (currentStep == 3)
            ShowStep(4);
    }

    public void RestartTraining()
    {
        ShowStep(0);
    }
}