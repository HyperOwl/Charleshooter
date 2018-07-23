using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]

public class PlayerController : MonoBehaviour {
    private Rigidbody2D rb;

    public float speed = 1;
    [Range(0,2)] [SerializeField]
    private float movementSmooth = 1;

    private Vector3 dampRef = Vector3.zero;
    private Vector2 movement;

	private void Start () {
        rb = GetComponent<Rigidbody2D>();
	}
	
	private void Update () {
        movement.x = Input.GetAxisRaw("Horizontal")*speed;
        movement.y = Input.GetAxisRaw("Vertical")*speed;
	}

    private void FixedUpdate()
    {
        Move(movement);
        FaceMouse();
    }

    public void Move(Vector2 movementVelocity)
    {
        Vector3 targetVelocity = movement;
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref dampRef, movementSmooth);
    }
    private void FaceMouse()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Vector2 mouseTransform = new Vector2(
            mousePosition.x - transform.position.x,
            mousePosition.y - transform.position.y);
        rb.transform.up = mouseTransform;
    }
}
