using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausaMenu : MonoBehaviour
{
    [SerializeField] GameObject menuPausa;

    public void Pause()
    {
        menuPausa.SetActive(true);
        Time.timeScale = 0;  //blocca il tempo
    }
    public void Home()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;  //blocca il tempo
    }
    public void Resume()
    {
        menuPausa.SetActive(false);
        Time.timeScale = 1;  //blocca il tempo
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;  //blocca il tempo
    }
}

