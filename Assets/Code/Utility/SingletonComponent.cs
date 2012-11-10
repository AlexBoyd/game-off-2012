using UnityEngine;
using System.Collections;

public class SingletonComponent<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T sInstance;

    public static T Instance
    {
        get
        {
            if(sInstance == null)
            {
                sInstance = (T)Object.FindObjectOfType(typeof(T));
            }
            return sInstance;
        }
    }

}
