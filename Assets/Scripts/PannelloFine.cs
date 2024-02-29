using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PannelloFine : MonoBehaviour
{
    public GestoreRisposte gestoreRisposte;
    public TextMeshPro testoPunti;
    public TextMeshPro testoRis;
    [SerializeField] GameObject pannelloFine;

    public void Fine()
    {
        float punti = gestoreRisposte.getPunti();
        float tempo = gestoreRisposte.getTempoMedio();
        testoPunti.text = "PUNTEGGIO: \n" + punti.ToString() + "\n\n" + "TEMPO MEDIO: \n" + tempo.ToString();
        testoRis.text = scegliFrase(punti);
        pannelloFine.SetActive(true);
    }
    string scegliFrase(float punti)
    {
        if (punti >= 20f)
        {
            return "BOOORGIISS!";
        }
        else if (punti >= 15f)
        {
            return "SEI UN GENIO";
        }
        else if (punti >= 12f)
        {
            return "SEI BRAVISSIMO";
        }
        else if (punti >= 8f)
        {
            return "SEI BRAVO";
        }
        else if (punti >= 5f)
        {
            return "TE LA CAVI";
        }
        else if (punti >= 2f)
        {
            return "PUOI FARE MEGLIO";
        }
        else
        {
            return "IMPEGNATI DI PIU'";
        }
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
