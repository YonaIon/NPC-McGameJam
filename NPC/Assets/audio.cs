using UnityEngine;

public class MusicPersistence : MonoBehaviour
{
    private static MusicPersistence instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Ensures this object survives scene changes
        }
        else
        {
            Destroy(gameObject); // Destroys duplicate instances
        }
    }
}
