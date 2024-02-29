//PROGETTO NUOVO
using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System.IO;


[System.Serializable]
public class Domanda
{
    public string question;
    public string correctAnswer;
    public List<string> wrongAnswer;
}

[System.Serializable]
public class DomandeContainer
{
    public List<Domanda> domande;
}


public class GestoreDomande : MonoBehaviour
{
    public TextMeshPro testoDomanda;
    public GameObject[] blocchi;
    private Domanda domandaCasuale;

    void Start()
    {
        // Recupera il percorso del file JSON memorizzato
        string percorsoFileJSON = PlayerPrefs.GetString("PercorsoFileJSON", "");

        // Carica il contenuto del file JSON
        if (!string.IsNullOrEmpty(percorsoFileJSON))
        {
            string filePath = Path.Combine(Application.streamingAssetsPath, percorsoFileJSON);
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                DomandeContainer domandeContainer = JsonUtility.FromJson<DomandeContainer>("{\"domande\":" + json + "}");

                // Seleziona una domanda casuale
                domandaCasuale = domandeContainer.domande[Random.Range(0, domandeContainer.domande.Count)];

                // Assegna il testo della domanda all'oggetto di testo
                if (testoDomanda != null)
                {
                    testoDomanda.text = domandaCasuale.question;
                }
                else
                {
                    Debug.LogError("Assicurati di avere un oggetto di testo UI o TextMeshProUGUI nella scena 2.");
                }

                // Ottieni tutte le possibili risposte (corrette e sbagliate)
                List<string> tutteLeRisposte = new List<string>();
                tutteLeRisposte.Add(domandaCasuale.correctAnswer);
                tutteLeRisposte.AddRange(domandaCasuale.wrongAnswer);

                // Mescola le risposte
                Shuffle(tutteLeRisposte);

                // Assegna le risposte ai blocchi
                for (int i = 0; i < blocchi.Length; i++)
                {
                    TextMeshPro testoBlocco = blocchi[i].GetComponentInChildren<TextMeshPro>();
                    if (testoBlocco != null)
                    {
                        testoBlocco.text = tutteLeRisposte[i];
                    }
                    else
                    {
                        Debug.LogError("Assicurati di avere un oggetto di testo UI o TextMeshProUGUI su ogni blocco.");
                    }
                }
            }
            else
            {
                Debug.LogError("Il file JSON delle domande non è stato trovato: " + filePath);
            }
        }
        else
        {
            Debug.LogError("Percorso del file JSON non specificato.");
        }
    }

    private Domanda getDomanda()
    {
        return domandaCasuale;
    }

    public void setDomanda(Domanda domanda)
    {
        domandaCasuale = domanda;
    }

    // Metodo per mescolare una lista
    private void Shuffle<T>(List<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }

    public string GetRispostaCorretta()
    {
        // Recupera il DomandeContainer corrente
        string percorsoFileJSON = PlayerPrefs.GetString("PercorsoFileJSON", "");
        string filePath = Path.Combine(Application.streamingAssetsPath, percorsoFileJSON);

        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            DomandeContainer domandeContainer = JsonUtility.FromJson<DomandeContainer>("{\"domande\":" + json + "}");

            // Seleziona la domanda corrente
            Domanda domandaCorrente = getDomanda();

            // Ritorna la risposta corretta della domanda corrente
            return domandaCorrente.correctAnswer;
        }
        else
        {
            UnityEngine.Debug.Log("Il file JSON delle domande non è stato trovato: " + filePath);
            return null;
        }
    }

    public DomandeContainer GetDomandeContainer()
    {

        string percorsoFileJSON = PlayerPrefs.GetString("PercorsoFileJSON", "");
        string filePath = Path.Combine(Application.streamingAssetsPath, percorsoFileJSON);
        string json = File.ReadAllText(filePath);
        DomandeContainer domandeContainer = JsonUtility.FromJson<DomandeContainer>("{\"domande\":" + json + "}");
        return domandeContainer;
    }
}