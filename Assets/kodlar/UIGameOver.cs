using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIGameOver : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    Skor skor;

    void Awake()
    {
        skor = FindObjectOfType<Skor>();
    }

    void Start()
    {
        scoreText.text = "Your Score:\n" + skor.GetSkor().ToString();
    }

}
