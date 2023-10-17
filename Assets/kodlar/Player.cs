using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] float hareketHızı = 4f;
    [SerializeField] float solDolgu;
    [SerializeField] float sağDolgu;
    [SerializeField] float üstDolgu;
    [SerializeField] float altDolgu;
    Vector2 minimumHareket;
    Vector2 maxHareket;
    Shooter shooter;

    Vector2 hareketGirdisi;

    void Awake() 
    {
        shooter = GetComponent<Shooter>();
    }

    void Start() 
    {
        HareketKısıtlama();
    }
   
    void Update()
    {
        Move();
    }

    void HareketKısıtlama()
    {
        Camera mainCamera = Camera.main;
        minimumHareket = mainCamera.ViewportToWorldPoint (new Vector2(0,0));
        maxHareket = mainCamera.ViewportToWorldPoint (new Vector2(1,1));
    }

    void Move()
    {
        Vector2 delta = hareketGirdisi * hareketHızı * Time.deltaTime;
        Vector2 yeniPozisyon = new Vector2();
        yeniPozisyon.x = Mathf.Clamp(transform.position.x + delta.x,minimumHareket.x + solDolgu, maxHareket.x - sağDolgu);
        yeniPozisyon.y = Mathf.Clamp(transform.position.y + delta.y,minimumHareket.y + altDolgu, maxHareket.y - üstDolgu);
        transform.position = yeniPozisyon;
    }

    void OnMove(InputValue değer)
    {
        hareketGirdisi = değer.Get<Vector2>();
    }

    void OnFire(InputValue değer)
    {
        if(shooter != null)
        {
            shooter.isFiring = değer.isPressed;
        }
        
    }
}
