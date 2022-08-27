using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject canvas;
    void Start()
    {
        Time.timeScale = 1f;
    }


    void Update()
    {
        LoseGame();
    }
    private void LoseGame()
    {
        if (player.transform.position.y < -5f)
        {
            Time.timeScale = 0f;
            canvas.SetActive(true);
        }
    }

    public void ReloadGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    
   
    

}
