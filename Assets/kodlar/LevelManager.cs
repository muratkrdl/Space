using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
     Skor score;
     void Awake() 
     {
          score = FindObjectOfType<Skor>();
     }
     [SerializeField] float loadSceneDelay = 2f;
     public void LoadGame()
     {
          SceneManager.LoadScene("Game");
          score.ResetSkor();
     }

     public void LoadGameOver()
     {
          StartCoroutine(WaitAndLoad("GameOver" , loadSceneDelay));
     }

     public void LoadMainMenu()
     {
          SceneManager.LoadScene("MainMenu");
     }

     public void QuitGame()
     {
          Debug.Log("Quiting the game ...");
          Application.Quit();
     }

     IEnumerator WaitAndLoad (string sceneName , float delay)
     {     
          yield return new WaitForSeconds(delay);
          SceneManager.LoadScene (sceneName);
     }
}
