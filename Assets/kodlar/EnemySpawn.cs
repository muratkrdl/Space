using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] List<RotaYapılandırma> waveConfigs;
    [SerializeField] float timeBetweenWave = 0f;
    [SerializeField] bool isLooping;
    RotaYapılandırma mevcutWave;
    void Start()
    {
        StartCoroutine(SpawnEnemyWaves());
    }

    public RotaYapılandırma GetMevcutWave()
    {
        return mevcutWave;
    }

    IEnumerator SpawnEnemyWaves()
    {
        do
        {
            foreach(RotaYapılandırma wave in waveConfigs)
            {
                mevcutWave = wave;
                for(int i = 0 ; i < mevcutWave.GetEnemySayısı(); i++)
                {
                    Instantiate(mevcutWave.GetEnemyPrefabs(i), mevcutWave.GetBaşlangıçNoktası().position, Quaternion.identity, transform);
                    yield return new WaitForSeconds(mevcutWave.GetRandomSpawnTime());
                }
                yield return new WaitForSeconds(timeBetweenWave);
            }
        }
        while(isLooping);
        
    }

}
