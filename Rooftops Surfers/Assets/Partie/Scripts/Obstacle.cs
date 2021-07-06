using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public Compteur Interface;

    private void Start()
    {
        Interface = GameObject.Find("Interface").GetComponent<Compteur>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Joueur>() is null) return;
        
        Interface.stop = true;
    }
}
