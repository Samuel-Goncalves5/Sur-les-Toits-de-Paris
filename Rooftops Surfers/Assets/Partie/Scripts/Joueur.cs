using UnityEngine;

public class Joueur : MonoBehaviour
{
    public bool Pause;
    
    public Transform[] positions;
    public int index;

    public float jumph;
    public float jumpforce;
    private Vector3 jump;
    private Rigidbody rigg;
    public bool canjump;
    private Transform t;
    private void Start()
    {
        jump = new Vector3(0f, jumph, 0f);
        rigg = GetComponent<Rigidbody>();
        canjump = true;
        t = transform;
    }

    private void Update()
    {
        if (Pause) return;
        Animation();
        Jump();
        Move();
    }

    private bool avance;
    private void Animation()
    {
        if (avance)
        {
            var transformPosition = t.position;
            transformPosition.x += 0.005f;
            t.position = transformPosition;
            if (transform.position.x >= 0) avance = false;
        }
        else
        {
            var transformPosition = t.position;
            transformPosition.x -= 0.005f;
            t.position = transformPosition;
            if (transform.position.x <= -.0055) avance = true;
        }
    }

    private void Jump()
    {
        if (canjump && Input.GetKeyDown(KeyCode.UpArrow))
        {
            rigg.AddForce(jump * jumpforce, ForceMode.Impulse);
            canjump = false;
        }
    }

    private void Move()
    {
        if (index < 2 && Input.GetKeyDown(KeyCode.RightArrow))
        {
            index++;
            
            var transformPosition = t.position;
            transformPosition.z = positions[index].position.z;
            t.position = transformPosition;
        }

        if (index > 0 && Input.GetKeyDown(KeyCode.LeftArrow))
        {
            index--;
            
            var transformPosition = t.position;
            transformPosition.z = positions[index].position.z;
            t.position = transformPosition;
        }
    }
}
