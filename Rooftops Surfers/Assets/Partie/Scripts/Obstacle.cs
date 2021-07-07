using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public Compteur Interface;
    public AudioManager AudioManager;

    private void Start()
    {
        Interface = GameObject.Find("Interface").GetComponent<Compteur>();
        AudioManager = GameObject.Find("AudioManager").GetComponent<AudioManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Joueur>() is null)
        {
            if (other.GetComponent<Obstacle>() is null) return;
            Destroy(other.gameObject);
        }
        else
        {
            AudioManager.Play("Contact");
            Interface.stop = true;
        }
    }
}
