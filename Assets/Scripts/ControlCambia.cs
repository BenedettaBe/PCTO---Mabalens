using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class GestoreBottoni : MonoBehaviour
{
    public string percorsoFileJSON = "questions/history/"; // Percorso predefinito del file JSON

    public void CambiaScenaEMemorizzaPercorso()
    {
        string livello = PlayerPrefs.GetString("LivelloJSON", "");
        string percorsoCompleto = percorsoFileJSON + livello;
        PlayerPrefs.SetString("PercorsoFileJSON", percorsoCompleto);

        SceneManager.LoadScene(1);
    }
}