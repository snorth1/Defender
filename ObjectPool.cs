using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] [Range(0.1f, 20f)] private float spawnTimer = 1f;
    [SerializeField] [Range(0f, 50f)] private int poolSize = 5;

    private GameObject[] pool;

    void Awake()
    {
        PopulatePool();        
    }

    public void PopulatePool()
    {
        pool = new GameObject[poolSize];

        for(int i = 0; i < poolSize; i++)
        {
            pool[i] = Instantiate(enemyPrefab, transform);
            pool[i].SetActive(false);
        }
    }

    void Start() 
    {
        StartCoroutine(SpawnEnemy());     
    }

    public IEnumerator SpawnEnemy()
    {
        while(true)
        {         
            EnableObjectInPool();   
            yield return new WaitForSeconds(spawnTimer);
        }
    }

    void EnableObjectInPool()
    {
        for(int i = 0; i < poolSize; i++)
        {
            if(pool[i].activeInHierarchy == false)
            {
                pool[i].SetActive(true);
                return;
            }
        }
    }

}
