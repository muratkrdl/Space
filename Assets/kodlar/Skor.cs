using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skor : MonoBehaviour
{
    int skor = 0;

    static Skor örnek; 

    void Awake() 
    {
        ManageSingletonScore();
    }

    void ManageSingletonScore()
    {
        if(örnek != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            örnek = this;
            DontDestroyOnLoad(gameObject);
        }
    }


    public int GetSkorUp()
    {
        return skor;
    }

    public void SkorModifiye(int değer)
    {
        skor += değer;
        Mathf.Clamp (skor,0,int.MaxValue);
    }

    public void ResetSkor()
    {
        skor = 0;
    }

    public int GetSkor()
    {
        return skor;
    }


}
