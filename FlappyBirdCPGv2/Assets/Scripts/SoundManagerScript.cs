
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
    public static AudioClip WingClap, Die, PointEarned, Bomb;
    static AudioSource AudioSource;
    void Start()
    {
        WingClap = Resources.Load<AudioClip>("Wing");
        Die = Resources.Load<AudioClip>("die");
        PointEarned = Resources.Load<AudioClip>("point");
        Bomb = Resources.Load<AudioClip>("Bomb");
        AudioSource = GetComponent<AudioSource>();
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "Wing":
                AudioSource.PlayOneShot(WingClap);
                break;
            case "die":
                AudioSource.PlayOneShot(Die);
                break;
            case "point":
                AudioSource.PlayOneShot(PointEarned);
                break;
            case "Bomb":
                AudioSource.PlayOneShot(Bomb);
                break;
        }
    }
}
