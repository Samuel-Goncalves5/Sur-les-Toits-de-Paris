using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public Compteur Interface;
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Joueur>() is null) return;
        
        Interface.stop = true;
    }
}
