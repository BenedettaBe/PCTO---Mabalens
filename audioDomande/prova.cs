using System.Diagnostics;
using UnityEngine;
using UnityEngine.Windows.Speech;
using System.IO;
using System.Collections;
using UnityEngine.Networking;
using System.Threading;

public class Sounds : MonoBehaviour
{
    private AudioSource audioSource;
    private AudioClip readingClip;

    void Start()
    {
        string pythonFileName = "txtToMp3.py";
        string scriptDirectory = Application.dataPath;

        string mp3FilePath = scriptDirectory+ "/audio.mp3";

        RunPythonScript(pythonFileName, scriptDirectory);
        UnityEngine.Debug.Log(scriptDirectory);

        PlayMp3File(scriptDirectory, mp3FilePath);
    }

    void RunPythonScript(string pythonFileName, string scriptDirectory)
    {
        Process process = new Process();
        process.StartInfo.FileName = "python";
        process.StartInfo.Arguments = pythonFileName;
        process.StartInfo.WorkingDirectory = scriptDirectory;
        process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
        process.Start();
        process.WaitForExit();
    }

    void PlayMp3File(string scriptDirectory, string mp3FilePath)
    {
        string mp3MetaFilePath = scriptDirectory + "/audio.meta";

        UnityEngine.Debug.Log("file path"+mp3FilePath);


        Thread.Sleep(5000);
        PlayAudio();
    }

    void PlayAudio()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        readingClip = Resources.Load<AudioClip>("audio");

        if (readingClip != null)
        {
            audioSource.volume = 1.0f;
            audioSource.clip = readingClip;
            audioSource.Play();
        }
        else
        {
            UnityEngine.Debug.Log("Impossibile trovare o caricare l'audio da Resources.");
        }
    }

    


}

