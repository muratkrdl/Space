using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Rota Config" , fileName = "Yeni Rota")]
public class RotaYapılandırma : ScriptableObject
{
    [SerializeField] List<GameObject> enemyPrefabs;
    [SerializeField] Transform rotaPrefab;
    [SerializeField] float hareketHızı = 5f;
    [SerializeField] float timeBetweenEnemySpawns = 1f;
    [SerializeField] float spawnTimeVariance = 0f;
    [SerializeField] float minSpawnTime = 0f;

    public Transform GetBaşlangıçNoktası()
    {
        return rotaPrefab.GetChild(0);
    }
    public int GetEnemySayısı()
    {
        return enemyPrefabs.Count;
    }

    public GameObject GetEnemyPrefabs(int index)
    {
        return enemyPrefabs[index];
    }

    public List<Transform> GetRotaNoktaları()
    {
        List<Transform> RotaNoktaları = new List<Transform>();
        foreach(Transform child in rotaPrefab)
        {
            RotaNoktaları.Add(child);
        }
        return RotaNoktaları;
    }

   public float GetHareketHızı()
   {
        return hareketHızı;
   }

    public float GetRandomSpawnTime()
    {
        float SpawnTime = Random.Range(timeBetweenEnemySpawns - spawnTimeVariance, timeBetweenEnemySpawns + spawnTimeVariance);
        return Mathf.Clamp (SpawnTime, minSpawnTime, float.MaxValue);
    }

}
