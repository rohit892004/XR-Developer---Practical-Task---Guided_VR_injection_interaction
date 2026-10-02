using UnityEngine;

public class SyringeNeedle : MonoBehaviour
{
    [Header("Syringe")]
    public SyringeMedicine syringe;

    [Header("Medicine")]
    public string medicineTag = "Medicine";

    private bool insideMedicine = false;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Needle touched: " + other.name);

        if (other.CompareTag(medicineTag))
        {
            insideMedicine = true;
            Debug.Log("===== MEDICINE DETECTED =====");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag(medicineTag))
        {
            insideMedicine = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(medicineTag))
        {
            insideMedicine = false;
            Debug.Log("Medicine exited");
        }
    }

    private void Update()
    {
        if (insideMedicine && syringe != null)
        {
            syringe.FillMedicine();
        }
    }
}