using UnityEngine;

public class WorldMoveController : MonoBehaviour
{
    [SerializeField] float Speed;

    void Update()
    {
        transform.position += Vector3.left * Speed * Time.deltaTime;
    }
}
