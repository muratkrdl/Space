using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YolBulucu : MonoBehaviour
{
    EnemySpawn enemySpawn;
    RotaYapılandırma rotaYapılandırma;
    List<Transform> yolNoktaları;
    int numaraİndexi = 0;

    void Awake() 
    {
        enemySpawn = FindObjectOfType<EnemySpawn>();
    }

    void Start()
    {
        rotaYapılandırma = enemySpawn.GetMevcutWave();
        yolNoktaları = rotaYapılandırma.GetRotaNoktaları();
        transform.position = yolNoktaları[numaraİndexi].position;
    }
    void Update()
    {
        YoluTakipEt();
    }
    void YoluTakipEt()
    {
        if(numaraİndexi < yolNoktaları.Count)
        {
            Vector3 hedefPozisyon = yolNoktaları[numaraİndexi].position;
            float realHareketHızı = rotaYapılandırma.GetHareketHızı() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, hedefPozisyon, realHareketHızı);
            if(transform.position == hedefPozisyon)
            {
                numaraİndexi++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
