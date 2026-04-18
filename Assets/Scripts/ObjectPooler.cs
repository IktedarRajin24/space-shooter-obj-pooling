using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [SerializeField] private GameObject objectPrefab;
    [SerializeField] private int poolSize = 10;

    private List<GameObject> objectPool;

    private void InitializePool()
    {
        objectPool = new List<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            CreateNewObject();
        }
    }

    private GameObject GetPooledObject()
    {
        foreach (GameObject gameObject in objectPool)
        {
            if (!gameObject.activeInHierarchy)
            {
                return gameObject;
            }
        }

        return CreateNewObject();
    }

    private GameObject CreateNewObject()
    {
        GameObject obj = Instantiate(objectPrefab, Vector2.zero, Quaternion.identity);
        obj.SetActive(false);
        objectPool.Add(obj);
        return obj;
    }
}
