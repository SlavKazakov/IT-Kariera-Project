using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    bool GameEnd = false;
    public void GameOver()
    {
        if(GameEnd == false)
        {
            GameEnd = true;
            Destroy(gameObject);
            FindObjectOfType<GameOverScreen>().OnGameOverEvent();
        }       
    }
}
