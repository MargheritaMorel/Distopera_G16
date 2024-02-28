using UnityEngine;

public class SoundOnTrigger : MonoBehaviour
{
    [SerializeField] AudioSource audioSource;

    private void Start()
    {
        // Ottieni il componente AudioSource
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            // Se non c'è alcun AudioSource, aggiungilo
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Assegna il suono al componente AudioSource
       
    }

    private void OnTriggerEnter(Collider other)
    {
        // Controlla se l'oggetto ha toccato terra (puoi modificare questa condizione in base alle tue esigenze)
        if (other.CompareTag("Ground"))
        {
            // Riproduci il suono
            audioSource.Play();
        }
    }
}
