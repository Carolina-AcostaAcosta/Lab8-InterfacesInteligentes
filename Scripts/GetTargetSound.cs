using UnityEngine;

public class GetTargetSound : MonoBehaviour
{
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EscudoTipo1Especial") || other.CompareTag("EscudoTipo1") || other.CompareTag("EscudoTipo2"))
        {
            EventManager.TargetSound();
        }
    }

    void Update()
    {
        
    }

    private void OnEnable()
    {
        EventManager.OnTargetSound += HandleTargetSound;
    }

    private void OnDisable()
    {
        EventManager.OnTargetSound -= HandleTargetSound;
    }

    private void HandleTargetSound()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        if (audioSource != null)
        {
            audioSource.Play();
        }
    }
}
    