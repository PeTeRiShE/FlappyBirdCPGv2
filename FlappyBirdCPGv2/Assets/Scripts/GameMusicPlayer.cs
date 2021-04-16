using UnityEngine;


public class GameMusicPlayer : MonoBehaviour
{

    private static GameMusicPlayer Instance;
    public static GameMusicPlayer GetInstance
    {
        get
        {
            return Instance;

        }
    }
    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            Instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }
}