using UnityEngine;
using TMPro;
using System.Collections.Generic;
using System.IO;

//PROGETTO NUOVO 

public class GestoreRisposte : MonoBehaviour
{
    public Material materialeCorrettoPersonalizzato;
    public Material materialeErratoPersonalizzato;

    private Renderer ultimoBloccoSelezionato;
    private bool rispostaCorrettaSelezionata;

    private GestoreDomande gestoreDomande;

    private DomandeContainer domandeContainer;

    public List<GameObject> blocchi;

    void Start()
    {

        gestoreDomande = FindObjectOfType<GestoreDomande>();
        if (gestoreDomande == null)
        {
            Debug.LogError("GestoreDomande non trovato.");
            return;
        }

        // Otteniamo DomandeContainer
        domandeContainer = gestoreDomande.GetDomandeContainer();
        if (domandeContainer == null)
        {
            Debug.LogError("DomandeContainer non trovato in GestoreDomande.");
            return;
        }

        rispostaCorrettaSelezionata = false;
    }

    public void SelezionaRisposta(GameObject blocco)
    {

        gestoreDomande = FindObjectOfType<GestoreDomande>();
        if (gestoreDomande == null)
        {
            Debug.LogError("GestoreDomande non trovato.");
            return;
        }

        // Otteniamo DomandeContainer
        domandeContainer = gestoreDomande.GetDomandeContainer();
        if (domandeContainer == null)
        {
            Debug.LogError("DomandeContainer non trovato in GestoreDomande.");
            return;
        }


        if (rispostaCorrettaSelezionata)
        {
            return;
        }


        Renderer rendererBlocco = blocco.GetComponent<Renderer>();

        // Otteniamo la risposta corretta dalla domanda corrente
        string rispostaCorretta = gestoreDomande.GetRispostaCorretta();
        UnityEngine.Debug.Log("Risposta corretta: " + rispostaCorretta);

        // Otteniamo tutte le risposte disponibili sulla base della domanda corrente
        List<string> tutteLeRisposte = new List<string>();
        foreach (var domanda in domandeContainer.domande)
        {
            tutteLeRisposte.Add(domanda.correctAnswer);
            tutteLeRisposte.AddRange(domanda.wrongAnswer);
        }

        // Controlliamo se la risposta corretta è presente tra le opzioni disponibili
        if (!tutteLeRisposte.Contains(rispostaCorretta))
        {
            Debug.LogError("La risposta corretta non è tra le opzioni disponibili.");
            return;
        }

        // Se la risposta corretta è tra le opzioni, procediamo con la selezione
        string testoBlocco = blocco.GetComponentInChildren<TextMeshPro>().text;
        ColoraBlocchi(blocchi);
        /*
        if (testoBlocco == rispostaCorretta)
        {
            rendererBlocco.material = materialeCorrettoPersonalizzato;
            rispostaCorrettaSelezionata = true;
        }
        else
        {
            rendererBlocco.material = materialeErratoPersonalizzato;
        }

        ultimoBloccoSelezionato = rendererBlocco;*/
    }


    public void ColoraBlocchi(List<GameObject> blocchi)
    {
        // Itera su tutti i blocchi
        foreach (GameObject blocco in blocchi)
        {
            Renderer rendererBlocco = blocco.GetComponent<Renderer>();
            string testoBlocco = blocco.GetComponentInChildren<TextMeshPro>().text;

            // Otteniamo la risposta corretta dalla domanda corrente
            string rispostaCorretta = gestoreDomande.GetRispostaCorretta();

            // Verifichiamo se il testo del blocco corrente corrisponde alla risposta corretta
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
}