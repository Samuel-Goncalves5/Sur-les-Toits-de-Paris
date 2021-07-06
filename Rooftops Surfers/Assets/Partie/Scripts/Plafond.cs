using UnityEngine;

public class Plafond : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Joueur>() is null) return;

        Vector3 temp = other.transform.position;
        other.transform.position = new Vector3(temp.x, 0.146f, temp.z);
    }
}
