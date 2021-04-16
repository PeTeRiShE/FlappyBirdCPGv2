using UnityEngine;

[CreateAssetMenu(fileName = "Pipes", menuName = "Pipes for flappy")]
public class PipesScriptable : ScriptableObject
{
    public GameObject PipePrefab;
    public Color Color;
    public Texture2D Texture;
    public int ScoreToAppear;
}
