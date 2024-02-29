using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelezLivello : MonoBehaviour
{
    public string livello;

    public void prendiLivello()
    {
        string path_livello = livello + ".json";
        PlayerPrefs.SetString("LivelloJSON", path_livello);
    }
    
}
