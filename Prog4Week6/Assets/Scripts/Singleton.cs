using System.Runtime.CompilerServices;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{

    private static T instance;

    public static T Instance
    {

        get { return instance; }

    }

    private static T GetInstance()
    {

        if(instance == null)
        {

            instance = FindFirstObjectByType<T>();
            if(instance == null)
            {
                new GameObject(typeof(T).ToString(), typeof(T));
            }
            else if(instance.gameObject.scene.name != "DontDestroyOnLoad")
            {
                DontDestroyOnLoad(instance.gameObject);
            }

        }

        return instance;

    }

    // Update is called once per frame
    void Awake()
    {

        GetInstance();

        if(instance != null && instance != this)
        {

            Debug.LogWarning($"Destroying duplicate {typeof(T)} component.");
            Destroy(this);

        }

    }
}
