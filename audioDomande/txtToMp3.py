import pyttsx3
from pydub import AudioSegment

def crea_audio(testo, output_path="Resources/audio.mp3"):
    engine = pyttsx3.init()
    engine.setProperty('rate', 150)

    # Utilizza il percorso specificato in output_path per il salvataggio
    engine.save_to_file(testo, output_path)
    engine.runAndWait()

    # Carica il file audio generato
    audio_clip = AudioSegment.from_file('audio.mp3', format='mp3')

    # Salva il file audio in formato MP4
    audio_clip.export(output_path, format='mp3', codec='aac')

def chiamata(x):
    crea_audio(x, output_path='Resources/audio.mp3')
    
if __name__ == "__main__":
    chiamata("ciao sono borgis")
    
