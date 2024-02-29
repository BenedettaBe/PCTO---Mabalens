using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PannelloFine : MonoBehaviour
{
    public GestoreRisposte gestoreRisposte;
    public TextMeshPro testoPunti;
    [SerializeField] GameObject pannelloFine;

    public void Fine()
    {
        float punti = gestoreRisposte.getPunti();
        testoPunti.text = "Punteggio: \n" + punti.ToString();
        pannelloFine.SetActive(true);

    }
    public void Home()
    {
        SceneManager.LoadScene(0);
    }
    
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
