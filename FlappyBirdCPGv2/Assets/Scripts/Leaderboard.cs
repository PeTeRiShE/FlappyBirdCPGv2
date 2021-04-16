using UnityEngine;
using UnityEngine.UI;


public class Leaderboard : MonoBehaviour
{
    public Text[] HighScores;
    public GameObject HighScoreEarnedCanvas;

    int[] HighScoreValues;
    void Start()
    {
        HighScoreEarnedCanvas.SetActive(false);
        HighScoreValues = new int[HighScores.Length];
        for (int i = 0; i < HighScores.Length; i++)
        {
            HighScoreValues[i] = PlayerPrefs.GetInt("highScoreValues" + i);
        }
        DrawScores();
    }

    void SaveScores()
    {
        for (int i = 0; i < HighScores.Length; i++)
        {
            PlayerPrefs.SetInt("highScoreValues" + i, HighScoreValues[i]);

        }
    }

    public void CheckForHighScore(int Value)
    {
        for (int i = 0; i < HighScoreValues.Length; i++)
        {
            if (Value > HighScoreValues[i])
            {
                for (int j = HighScores.Length - 1; j > i; j--)
                {
                    HighScoreValues[j] = HighScoreValues[j - 1];
                }
                HighScoreValues[i] = Value;
                DrawScores();
                SaveScores();
                HighScoreEarnedCanvas.SetActive(true);
                break;
            }
        }
    }
    void DrawScores()
    {

        for (int i = 0; i < HighScores.Length; i++)
        {
            HighScores[i].text = HighScoreValues[i].ToString();
        }
    }
}