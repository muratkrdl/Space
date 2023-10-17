using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 50;
    [SerializeField] int skorUp = 50;
    [SerializeField] ParticleSystem explosion;
    [SerializeField] bool oyuncuyaShake;
    [SerializeField] bool oyuncuSkor;
    KameraSallanma kameraSallanma;
    AudioPlayer audioPlayer;
    Skor skor;
    LevelManager levelManager;

    void Awake() 
    {
        kameraSallanma = Camera.main.GetComponent<KameraSallanma>();
        audioPlayer = FindObjectOfType<AudioPlayer>();
        levelManager = FindObjectOfType<LevelManager>();
        skor = FindObjectOfType<Skor>();
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        TakeDamage takeDamage = other.GetComponent<TakeDamage>();
        
        if(takeDamage != null)
        {
            HasarAlma(takeDamage.GetDamage());
            ExploFX();
            audioPlayer.PlayPatlamaSesi();
            PlayShakee();
            takeDamage.Hit();
        }
    }

    void HasarAlma(int damage)
    {
        health -= damage;
        Debug.Log(health);
        if(health <= 0)
        {
            if(!oyuncuSkor)
            {
                skor.SkorModifiye(skorUp);
            }
            else
            {
                levelManager.LoadGameOver();
            }
            Destroy(gameObject);
        }
    }

    void ExploFX()
    {
        if(explosion != null)
        {
            ParticleSystem örnek = Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(örnek.gameObject, örnek.main.duration + örnek.main.startLifetime.constantMax);
        }
    }

    void PlayShakee()
    {
        if(oyuncuyaShake)   // kameraSallanma != null;
        {
            kameraSallanma.ShakePlay();
        }
    }

    public int GetHealth()
    {
        return health;
    }

}
