using UnityEngine;

public class PipeSpawner : MonoBehaviour, IPooledObjects
{
    [SerializeField] float TimeToWaitBeforeSpawn = 1f;
    [SerializeField] float Height; 
    private float TimeCounter = 0f;
    public int PipesOnScreen;

    public void OnObjectSpawn()
    {

    }
    private void FixedUpdate()
    {
        if (TimeCounter > TimeToWaitBeforeSpawn)
        {
                ObjectPool.GetInstance.SpawnFromPool(transform.position + new Vector3(0, Random.Range(-Height, Height)), Quaternion.identity);
                TimeCounter = 0;
        }
        TimeCounter += Time.deltaTime;
    }
}
