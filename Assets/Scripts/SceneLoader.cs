using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{   
    public void LoadGameScene()
    {
        SceneManager.LoadScene("Game");
        FindObjectOfType<GameScore>().ResetGame();
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene("Start Scene");
    }

    public void LoadGameOverScene()
    {
        StartCoroutine(Wait());        
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("GameOver");
    }
}
