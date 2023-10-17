using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundScrolling : MonoBehaviour
{
    [SerializeField] float hareketHızı;
    Vector2 offset;
    Material scrollingMaterial;

    void Awake()
    {
        scrollingMaterial = GetComponent<SpriteRenderer>().material;
    }

    
    void Update()
    {
        offset = new Vector2 (0, hareketHızı) * Time.deltaTime;
        scrollingMaterial.mainTextureOffset += offset;
    }
}
