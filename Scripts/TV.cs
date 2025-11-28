using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TV : MonoBehaviour
{
    // Declaración de variables: Material, WebCamTextura y String para almacenar el path del directorio donde almacenar las imágenes.
    private Material tvMaterial;
    private WebCamTexture webCamTexture;
    public string imageSavePath;

    int captureCounter = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Inicializar el material al que posteriormente se asignará cada imagen-frame de la cámara.
        // Es necesario obtener el Renderer del objeto sobre el que se pinta, y acceder a su material.
        // Usar el constructor de WebCamTexture para inicializar una variable de ese tipo.
        tvMaterial = GetComponent<Renderer>().material;
        webCamTexture = new WebCamTexture();

        // Mostrar nombre de la cámara en consola
        Debug.Log("Cámara por defecto: " + WebCamTexture.devices[0].name);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("s")) {
            // Asignar a la mainTexture del material lo que capta la cámara. La captura se inicia con nombrevariable_webcamtexture.Start()
            tvMaterial.mainTexture = webCamTexture;
            webCamTexture.Play();
        }

        if (Input.GetKey("p")) {
            // Parar la captura de la cámara con nombrevariable_webcamtexture.Stop()
            webCamTexture.Stop();
        }

        if (Input.GetKey("x")) {
            // Tomar fotogramas
            Texture2D snapshot = new Texture2D(webCamTexture.width, webCamTexture.height);
            snapshot.SetPixels(webCamTexture.GetPixels());
            snapshot.Apply();
            System.IO.File.WriteAllBytes(imageSavePath + captureCounter.ToString() + ".png", snapshot.EncodeToPNG());
            captureCounter++;
        }
    }
}
