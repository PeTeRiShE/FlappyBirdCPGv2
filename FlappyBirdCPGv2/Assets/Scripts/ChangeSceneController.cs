using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneController : MonoBehaviour
{
    public void ButtonChangeScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }

   
}
