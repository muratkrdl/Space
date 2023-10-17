using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header("General")]
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float bulletSpeed = 10f;
    [SerializeField] float bulletLifeTime = 5f;
    [SerializeField] float baseFireAralığı = 0.2f;
    [Header("Enemy")]
    [SerializeField] float firingRateVariance = 0f;
    [SerializeField] float minimumFireRate = 0.1f;
    [SerializeField] bool useEnemy;
    [HideInInspector] public bool isFiring;
    AudioPlayer auidoPlayer;
    Coroutine fireCoroutine;
    
    void Awake()
    {
        auidoPlayer = FindObjectOfType<AudioPlayer>();
    }

    void Start()
    {
        if(useEnemy)
        {
            isFiring = true;
        }
    }

    void Update()
    {
        if(isFiring && fireCoroutine == null)
        {
            fireCoroutine = StartCoroutine(SürekliFire());
        }
        else if(!isFiring && fireCoroutine != null)
        {
            StopCoroutine(fireCoroutine);
            fireCoroutine = null;
        }
    }

    IEnumerator SürekliFire()
    {
        while(true)
        {
            GameObject example = Instantiate (bulletPrefab, transform.position, Quaternion.identity);
            Rigidbody2D rb = example.GetComponent<Rigidbody2D>();
            if(rb != null)
            {
                rb.velocity = transform.up * bulletSpeed;
            }
            Destroy(example, bulletLifeTime);

            float randomFireRate = Random.Range (baseFireAralığı - firingRateVariance, baseFireAralığı + firingRateVariance);
            Mathf.Clamp (randomFireRate, minimumFireRate, float.MaxValue);
            auidoPlayer.PlayAteşEtmeSesi();
            yield return new WaitForSeconds(randomFireRate); 
        }    
    }

}
