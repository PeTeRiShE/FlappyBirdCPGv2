using UnityEngine;

public class AddScore : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SoundManagerScript.PlaySound("point");
        ScoreController.GetInstance.Score++;
    }
}
