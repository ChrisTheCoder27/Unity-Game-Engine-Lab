using Chapter.Singleton;
using UnityEngine;

public class FinishArea : MonoBehaviour
{
    void Awake()
    {
        GetComponent<Collider>().enabled = false;
    }

    void Update()
    {
        if (UIManager.Instance.GetFinishLevel() == true)
        {
            GetComponent<Collider>().enabled = true;
        }
    }
}
