using UnityEngine;

public class PannelActive : MonoBehaviour
{
    public GameObject UI2;
    public GameObject UI3;
    public GameObject target;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        target.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Sirnge"))
        {
            UI2.SetActive(false);
            UI3.SetActive(true);
            target.SetActive(true);

        }
    }
}
