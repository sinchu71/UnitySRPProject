using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool Instance;  // ✅ Singleton instance for global access.

    private Queue<GameObject> poolQueue = new Queue<GameObject>();  // ✅ Queue holding pooled objects for reuse.

    private void Awake()
    {
        Instance = this;  // ✅ Initialize the Singleton instance.
    }

    public GameObject GetFromPool(GameObject prefab)
    {
        if (poolQueue.Count > 0)
        {
            GameObject obj = poolQueue.Dequeue();
            obj.SetActive(true);  // ✅ Reuse existing object by activating it.
            return obj;
        }
        else
        {
            return Instantiate(prefab);  // ✅ Create a new object if the pool is empty.
        }
    }

    public void ReturnToPool(GameObject obj)
    {
        obj.SetActive(false);  // ✅ Deactivate the object before pooling.
        poolQueue.Enqueue(obj);  // ✅ Add the object back to the pool for reuse.
    }
}
