
using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class GestoreRisposte : MonoBehaviour
{
    public Material materialeCorrettoPersonalizzato;
    public Material materialeErratoPersonalizzato;
    public Material materialeDefaultPersonalizzato;
    public TextMeshPro testoPunti;
    public TextMeshPro testoTempo;
    public TextMeshPro testoDomanda;
    public PannelloFine pannelloFine;

    private float tempoLimite = 10f; // Tempo limite in secondi
    private float tempoRimanente;
    private Coroutine countdownCoroutine; // Coroutine per il countdown del tempo

    private Renderer ultimoBloccoSelezionato;
    private bool rispostaCorrettaSelezionata;

    private List<float> tempiPerRisposta = new List<float>();
    private int contRisposte = 0;

    public float tempoMedioImpiegato;

    private GestoreDomande gestoreDomande;
    private DomandeContainer domandeContainer;
    private int k = 0;

    public List<GameObject> blocchi;

    void Start()
    {
        tempoRimanente = tempoLimite;
        UpdateTimerText();

        gestoreDomande = FindObjectOfType<GestoreDomande>();
        if (gestoreDomande == null)
        {
            Debug.LogError("GestoreDomande non trovato.");
            return;
        }

        domandeContainer = gestoreDomande.GetDomandeContainer();
        if (domandeContainer == null)
        {
            Debug.LogError("DomandeContainer non trovato in GestoreDomande.");
            return;
        }

        rispostaCorrettaSelezionata = false;

        GeneraNuovaDomanda(blocchi);
    }

    void UpdateTimerText()
    {
        if (testoTempo != null)
        {
            testoTempo.text = "Tempo: \n" + Mathf.Round(tempoRimanente).ToString();
        }
    }

    public float getPunti()
    {
        return k;
    }

    void StopTimer()
    {
        if (countdownCoroutine != null)
        {
            StopCoroutine(countdownCoroutine);
        }
    }

    void StartTimer()
    {
        countdownCoroutine = StartCoroutine(Countdown());
    }

    IEnumerator Countdown()
    {
        while (tempoRimanente > 0)
        {
            yield return new WaitForSeconds(1f);
            tempoRimanente -= 1f;
            UpdateTimerText();
        }
        // Tempo scaduto, gestisci l'evento qui
        pannelloFine.Fine();
    }

    void ReimpostaColoriBlocchi(List<GameObject> blocchi)
    {
        foreach (GameObject blocco in blocchi)
        {
            Renderer rendererBlocco = blocco.GetComponent<Renderer>();
            rendererBlocco.material = materialeDefaultPersonalizzato;
        }
    }

    public void SelezionaRisposta(GameObject blocco)
    {
        if (rispostaCorrettaSelezionata)
        {
            return;
        }

        Renderer rendererBlocco = blocco.GetComponent<Renderer>();
        string rispostaCorretta = gestoreDomande.GetRispostaCorretta();
        string testoBlocco = blocco.GetComponentInChildren<TextMeshPro>().text;

        ColoraBlocchi(blocchi);

        if (testoBlocco == rispostaCorretta)
        {
            rendererBlocco.material = materialeCorrettoPersonalizzato;
            rispostaCorrettaSelezionata = true;
            k += 1;
            testoPunti.text = "Punti: " + k.ToString();

           
            float tempoImpiegato = tempoLimite - tempoRimanente;
            tempiPerRisposta.Add(tempoImpiegato);
            contRisposte++;


            StopTimer();
            StartCoroutine(WaitAndGenerateNewQuestion());
        }
        else
        {
            rendererBlocco.material = materialeErratoPersonalizzato;
            /*
            float tempoImpiegato = tempoLimite - tempoRimanente;
            tempiPerRisposta[contRisposte] = tempoImpiegato;
            contRisposte += 1;*/

            StopTimer();
            tempoMedioImpiegato = getTempoMedioRisposta();
            tempiPerRisposta.Clear();
            contRisposte = 0;

            pannelloFine.Fine();
        }

        ultimoBloccoSelezionato = rendererBlocco;
    }
    public float getTempoMedio()
    {
        return tempoMedioImpiegato;
    }

    float getTempoMedioRisposta()
    {
        if (contRisposte > 0)
        {
            float sommaTempi = 0.0f;
            foreach (float tempo in tempiPerRisposta)
            {
                sommaTempi += tempo;
            }
            return sommaTempi / contRisposte;
        }
        else
        {
            return 0.0f;
        }
    }

    void GeneraNuovaDomanda(List<GameObject> blocchi)
    {
        ReimpostaColoriBlocchi(blocchi);

        tempoRimanente = tempoLimite;
        UpdateTimerText();
        StartTimer();

        Domanda domandaCasuale = domandeContainer.domande[Random.Range(0, domandeContainer.domande.Count)];
        gestoreDomande.setDomanda(domandaCasuale);

        if (testoDomanda != null)
        {
            testoDomanda.text = domandaCasuale.question;
        }
        else
        {
            Debug.LogError("Assicurati di avere un oggetto di testo UI o TextMeshProUGUI nella scena.");
            return;
        }

        List<string> tutteLeRisposte = new List<string>();
        tutteLeRisposte.Add(domandaCasuale.correctAnswer);
        tutteLeRisposte.AddRange(domandaCasuale.wrongAnswer);

        Shuffle(tutteLeRisposte);

        if (blocchi == null || blocchi.Count == 0)
        {
            Debug.LogError("La lista dei blocchi è vuota o non valida.");
            return;
        }

        if (tutteLeRisposte.Count != blocchi.Count)
        {
            Debug.LogError("Il numero di risposte non corrisponde al numero di blocchi.");
            return;
        }

        for (int i = 0; i < blocchi.Count; i++)
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

        rispostaCorrettaSelezionata = false;
    }

    IEnumerator WaitAndGenerateNewQuestion()
    {
        while (!rispostaCorrettaSelezionata)
        {
            yield return null;
        }
        tempoRimanente = tempoLimite;
        yield return new WaitForSeconds(2f);
        GeneraNuovaDomanda(blocchi);
    }

    public void ColoraBlocchi(List<GameObject> blocchi)
    {
        foreach (GameObject blocco in blocchi)
        {
            Renderer rendererBlocco = blocco.GetComponent<Renderer>();
            string testoBlocco = blocco.GetComponentInChildren<TextMeshPro>().text;
            string rispostaCorretta = gestoreDomande.GetRispostaCorretta();

            if (testoBlocco == rispostaCorretta)
            {
                rendererBlocco.material = materialeCorrettoPersonalizzato;
            }
            else
            {
                rendererBlocco.material = materialeErratoPersonalizzato;
            }
        }
    }

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
}