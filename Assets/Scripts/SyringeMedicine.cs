using UnityEngine;

public class SyringeMedicine : MonoBehaviour
{
    [Header("Medicine Liquid")]
    public Renderer medicineLiquid;

    [Header("Fill")]
    [Range(0f, 1f)]
    public float fillAmount = 0f;

    public float fillSpeed = 0.25f;

    private Material liquidMaterial;
    private Animator anim;

    [Header("Arrows")]
    public GameObject Arrow;
    public GameObject Arrow1;

    [Header("UI")]
    public GameObject UI1;
    public GameObject UI2;

    private bool isFilling = false;

    private static readonly int FillID =
        Shader.PropertyToID("_FillAmount");

    void Start()
    {
        if (medicineLiquid == null)
        {
            Debug.LogError("MedicineLiquid Renderer is NOT assigned!");
            return;
        }

        anim = GetComponentInChildren<Animator>();

        liquidMaterial = medicineLiquid.material;

        fillAmount = 0f;

        if (liquidMaterial.HasProperty(FillID))
        {
            liquidMaterial.SetFloat(FillID, fillAmount);
        }
        else
        {
            Debug.LogError("Shader does NOT contain _FillAmount property!");
        }
    }

    public void FillMedicine()
    {
        if (!isFilling)
        {
            if (anim != null)
            {
                anim.SetTrigger("Active");
            }

            isFilling = true;
        }

        fillAmount += fillSpeed * Time.deltaTime;
        fillAmount = Mathf.Clamp01(fillAmount);

        if (liquidMaterial != null &&
            liquidMaterial.HasProperty(FillID))
        {
            liquidMaterial.SetFloat(FillID, fillAmount);
        }

        Debug.Log("FILL = " + fillAmount);

        if (fillAmount >= 1f)
        {
            StopFilling();
        }
    }

    public void StopFilling()
    {
        isFilling = false;

        if (anim != null)
        {
            anim.SetBool("Active", false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Arrow"))
        {
            // Hide arrows
            if (Arrow != null)
                Arrow.SetActive(false);

            if (Arrow1 != null)
                Arrow1.SetActive(false);

            // Hide UI1
            if (UI1 != null)
                UI1.SetActive(false);

            // Show UI2
            if (UI2 != null)
                UI2.SetActive(true);

            Debug.Log("Arrow detected → UI1 hidden, UI2 shown");
        }
    }
}