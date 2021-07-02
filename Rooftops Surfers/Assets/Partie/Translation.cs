using UnityEngine;

public class Translation : MonoBehaviour
{
    public float x;
    public void Input()
    {
        transform.position += new Vector3(x,0,0);
    }
}