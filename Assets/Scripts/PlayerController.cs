using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    [Range(1f, 10f)]
    [SerializeField] private float speed;


    private Rigidbody rb => GetComponent<Rigidbody>();
    private Animator animator => GetComponent<Animator>();

    private void Awake()
    {
        instance = this;
    }

    public void Move(Vector2 inputMovement)
    {
        Vector3 direccion = new Vector3(inputMovement.x, 0f, inputMovement.y).normalized;
       
        transform.Translate(direccion * speed * Time.deltaTime);
        
        animator.SetFloat("MovX", inputMovement.x);
        animator.SetFloat("MovY", inputMovement.y);

    }
}
