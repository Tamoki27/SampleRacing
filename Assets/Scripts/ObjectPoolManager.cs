using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class ObjectPoolManager : MonoBehaviour {

    [Serializable]
    public class ObjectPoolEntry
    {
        [SerializeField]
        public GameObject prefab;
        [SerializeField]
        public int count;
    }

    public ObjectPoolEntry[] entries;

    [HideInInspector]
    public List<GameObject>[] pool;
    protected GameObject containerObject;
    public static ObjectPoolManager Instance { get { return instance; } }
    private static ObjectPoolManager instance = null;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
        InitializePool();
    }

    void InitializePool()
    {
        containerObject = new GameObject("ObjectPool");

        containerObject.transform.parent = transform;

        //Loop through the object prefabs and make a new list for each one.

        pool = new List<GameObject>[entries.Length];

        for (int i = 0; i < entries.Length; i++)
        {

            ObjectPoolEntry objectPrefab = entries[i];

            //create the repository and fill it

            pool[i] = new List<GameObject>();

            for (int n = 0; n < objectPrefab.count; n++)
            {

                GameObject newObj = Instantiate(objectPrefab.prefab) as GameObject;

                newObj.name = objectPrefab.prefab.name;

                PoolObject(newObj);
            }
        }
    }

    public GameObject GetObjectForType(string objectType, bool onlyPooled)
    {

        for (int i = 0; i < entries.Length; i++)

        {

            GameObject prefab = entries[i].prefab;

            if (prefab.name == objectType)

            {

                if (pool[i].Count > 0)

                {

                    GameObject pooledObject = pool[i][0];

                    pool[i].RemoveAt(0);

                    pooledObject.transform.parent = null;

                    pooledObject.SetActive(true);

                    return pooledObject;

                }

                if (!onlyPooled)

                {

                    GameObject newObj = Instantiate(entries[i].prefab) as GameObject;

                    newObj.name = entries[i].prefab.name;

                    return newObj;

                }

            }

        }

        //Otherwise no object of the specified type or none were left in the pool with onlyPooled set to true

        return null;

    }

    public void PoolObject(GameObject obj)

    {

        for (int i = 0; i < entries.Length; i++)

        {

            if (entries[i].prefab.name == obj.name)

            {

                obj.SetActive(false);

                obj.transform.parent = containerObject.transform;

                pool[i].Add(obj);

                return;

            }

        }

    }

}
