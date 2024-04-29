using UnityEngine;

public class SingletonMuzik : MonoBehaviour
{
    private static SingletonMuzik obje = null;

    void Awake()
    {
        if (obje == null)
        {
            obje = this;
            DontDestroyOnLoad(this);
        }
        else if (this != obje)
        {
            Destroy(gameObject);
        }
    }
}
