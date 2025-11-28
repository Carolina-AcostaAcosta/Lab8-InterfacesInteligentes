using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Recorder : MonoBehaviour
{
    private AudioSource audioSource;
    private bool esperandoMicrofono = false;
    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        // Iniciar la recogida de audio por el micrófono
        audioSource.loop = true;
        
    }

    // Update is called once per frame
    void Update()
    {
        // En cada frame verificar si se ha pulsado la tecla R para iniciar la recogida de audio desde el micrófono
        if (Input.GetKeyDown(KeyCode.R))
        {
            audioSource.clip = Microphone.Start(null, true, 10, 44100);
            esperandoMicrofono = true;
        }

        if (esperandoMicrofono && Microphone.IsRecording(null))
        {
            // Verificamos si el micro ya ha escrito datos en el buffer (> 0)
            if (Microphone.GetPosition(null) > 0)
            {
                audioSource.Play();
                esperandoMicrofono = false;
            }
        }

        // En cada frame verificar si el usuario ha decidido parar el micrófono
        if (Input.GetKeyUp(KeyCode.R))
        {
            // Finalizar la captación de audio por el micrófono
            audioSource.Stop();
            Microphone.End(null);
            esperandoMicrofono = false;
        }
        
    }
}
