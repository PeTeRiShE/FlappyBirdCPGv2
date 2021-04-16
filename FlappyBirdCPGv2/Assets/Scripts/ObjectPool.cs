using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string Tag;
        public PipesScriptable ScriptableOfPipes;
        public int Size;
    }
    #region Singelton

    public static ObjectPool GetInstance;
   
    private void Awake()
    {

        if (GetInstance == null)
        {
            GetInstance = this;

        }

    }
    #endregion
    public List<Pool> Pools;
    public Dictionary<string, Queue<GameObject>> PoolDictionary;

    void Start()
    {
        PoolDictionary = new Dictionary<string, Queue<GameObject>>();
        foreach (Pool Pool in Pools)
        {
            Queue<GameObject> ObjectPool = new Queue<GameObject>();
            for (int i = 0; i < Pool.Size; i++)
            {
                GameObject Obj = Instantiate(Pool.ScriptableOfPipes.PipePrefab);
                foreach (SpriteRenderer spriteRenderer in Obj.GetComponentsInChildren<SpriteRenderer>())
                {
                    spriteRenderer.color = Pool.ScriptableOfPipes.Color;
                }
                Obj.SetActive(false);
                ObjectPool.Enqueue(Obj);
            }
            PoolDictionary.Add(Pool.Tag, ObjectPool);
        }
    }

    public GameObject SpawnFromPool(Vector3 Position, Quaternion Rotation)
    {
        List<Pool> pools = new List<Pool>();
        foreach (Pool Pool in Pools.OrderByDescending(a => a.ScriptableOfPipes.ScoreToAppear))
        {
            if (ScoreController.GetInstance.Score >= Pool.ScriptableOfPipes.ScoreToAppear)
            {
                pools.Add(Pool);
            }
        }

        if (!PoolDictionary.ContainsKey(pools[UnityEngine.Random.Range(0, pools.Count)].Tag))
        {
            Debug.LogWarning("Pool with tag " + pools[UnityEngine.Random.Range(0, pools.Count)].Tag + " doesnt exist");
            return null;
        }
        GameObject ObjectToSpawn = PoolDictionary[pools[UnityEngine.Random.Range(0, pools.Count)].Tag].Dequeue();
        ObjectToSpawn.SetActive(true);
        ObjectToSpawn.transform.position = Position;
        ObjectToSpawn.transform.rotation = Rotation;

        


        IPooledObjects PooledObj = ObjectToSpawn.GetComponent<IPooledObjects>();
        if (PooledObj != null)
        {
            PooledObj.OnObjectSpawn();
        }
        PoolDictionary[pools[UnityEngine.Random.Range(0, pools.Count)].Tag].Enqueue(ObjectToSpawn);
        return ObjectToSpawn;


    }

    public void HidePipes()
    {

        foreach(Queue <GameObject> queue in PoolDictionary.Values)
        {
            queue.ToList().ForEach(a => a.SetActive(false));

        }




    }

    
}
