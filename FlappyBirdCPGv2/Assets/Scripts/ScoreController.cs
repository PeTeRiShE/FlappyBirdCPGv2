using UnityEngine;
public class ScoreController : MonoBehaviour
{
    private static ScoreController Instance;
    public static ScoreController GetInstance
    {
        get
        {
            return Instance;
        }
    }
    private int score;
    public int Score
    {
        get
        {
            return score;
        }
        set
        {
            score = value;
            if (score % 10 == 0 && score != 0)
            {
                RainController.GetInstance.ChangeWeather();
                BombController.GetInstance.BombsCounter++;
            }
        }
    }
    private UnityEngine.UI.Text CachedUIText;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            
        }
        
    }

    private void Start()
    {
        CachedUIText = GetComponent<UnityEngine.UI.Text>();
        CachedUIText.text = Score.ToString();
    }
    private void Update()
    {
        CachedUIText.text = Score.ToString();
    }


}
