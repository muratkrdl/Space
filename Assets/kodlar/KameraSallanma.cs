using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KameraSallanma : MonoBehaviour
{
    [SerializeField] float sallanmaSüresi = 1f;
    [SerializeField] float sallanmaMiktarı = 0.5f;
    Vector3 başlangıçPozisyonu;
    
    void Start()
    {
        başlangıçPozisyonu = transform.position;
    }

    public void ShakePlay()
    {
        StartCoroutine(Shake());
    }

    IEnumerator Shake()
    {
        float geçenSüre = 0f;
        while(geçenSüre < sallanmaSüresi)
        {
        transform.position = başlangıçPozisyonu + (Vector3)Random.insideUnitCircle * sallanmaMiktarı;
        geçenSüre += Time.deltaTime;
        yield return new WaitForEndOfFrame();
        }
        transform.position = başlangıçPozisyonu;
    }
    
}
