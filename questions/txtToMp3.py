import pyttsx3
from pydub import AudioSegment
import json

def crea_audio(testo, output_path):
    engine = pyttsx3.init()
    engine.setProperty('rate', 150)

    # Utilizza il percorso specificato in output_path per il salvataggio
    engine.save_to_file(testo, output_path)
    engine.runAndWait()

def chiamata(x, output_path):
    crea_audio(x, output_path)
    
if __name__ == "__main__":
    with open('NOMEFILE.json', 'r') as file:
        data = json.load(file)
    print(len(data))
    for domanda in data:
        chiamata(domanda["question"], f"cartellaAudio/{domanda['question'][:-1]}.mp3")
    
