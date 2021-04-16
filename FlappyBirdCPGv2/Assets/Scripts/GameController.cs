using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField] GameObject gameOverCanvas;
    [SerializeField] GameObject LeaderboardCanvas;
    [SerializeField] GameObject ScoreCanvas;



    private void Start()
    {
        gameOverCanvas.SetActive(false);
        LeaderboardCanvas.SetActive(false);

        Time.timeScale = 1;


    }

    public void GameOver()
    {
        
        GetComponent<Leaderboard>().CheckForHighScore(ScoreController.GetInstance.Score);
        gameOverCanvas.SetActive(true);

        Time.timeScale = 0;

    }

    public void LeaderboardActivation()
    {
        
        GetComponent<Leaderboard>().HighScoreEarnedCanvas.SetActive(false);
        gameOverCanvas.SetActive(false);
        ScoreCanvas.SetActive(false);
        LeaderboardCanvas.SetActive(true);

    }


    public void Replay()
    {
        SceneManager.LoadScene(1);
    }
}
