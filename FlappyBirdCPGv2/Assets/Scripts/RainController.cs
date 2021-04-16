using UnityEngine;

public class RainController : MonoBehaviour
{
    [SerializeField] ParticleSystem RainGenerator;
    private Weather weather = Weather.Rainy;

    private static RainController Instance;
    public static RainController GetInstance
    {
        get
        {
            return Instance;
        }
    }

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

     
   
    public enum Weather
    {
        Sunny,
        Rainy
    }
    private void StartRain()
    {
        RainGenerator.enableEmission = true;
    }
    private void StopRain()
    {
        RainGenerator.enableEmission = false;
    }
    public void ChangeWeather()
    {
        switch (weather)
        {
            case Weather.Rainy:
                StopRain();
                Debug.LogWarning("Stop Rain fired");
                weather = Weather.Sunny;
                break;

            case Weather.Sunny:
                StartRain();
                Debug.LogWarning("Start rain fired");
                weather = Weather.Rainy;
                break;
        }
    }
}