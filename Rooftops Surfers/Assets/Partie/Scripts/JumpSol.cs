using UnityEngine;

public class JumpSol : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var temp = other.GetComponent<Joueur>();
        if (temp is null) return;
        temp.canjump = true;
    }
}
