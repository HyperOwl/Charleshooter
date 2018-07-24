using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]

public class PlayerController : MonoBehaviour {
    private Rigidbody2D rb;
    private PlayerWeapons weapons;
    [SerializeField]
    private ParticleSystem deathAnimation;
    [SerializeField]
    private SpawnManager spawnManager;
    [SerializeField]
    private Camera mainCam;
    [SerializeField]
    private Camera overhead;
    public bool dead = false;
    public float speed = 1;
    [Range(0,2)] [SerializeField]
    private float movementSmooth = 1;

    private Vector3 dampRef = Vector3.zero;
    private Vector2 movement;

    public int respawnFactor = 2;

	private void Start () {
        rb = GetComponent<Rigidbody2D>();
        weapons = GetComponent<PlayerWeapons>();
        mainCam.enabled = true;
        overhead.enabled = false;
	}
	
	private void Update () {
        movement.x = Input.GetAxisRaw("Horizontal")*speed;
        movement.y = Input.GetAxisRaw("Vertical") * speed;
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            EnemyController ec = collision.gameObject.GetComponent<EnemyController>();
            if (weapons.shield == PlayerWeapons.WeaponState.Active)
            {
                ec.Die();
                weapons.shield = PlayerWeapons.WeaponState.Reloading;
            }
            else
            {
                dead = true;
                Instantiate(deathAnimation, transform.position, transform.rotation, null);
                spawnManager.isDead();
                Destroy(gameObject);
                Debug.Log("YOU FAILED");
                ec.Die();
                mainCam.enabled = false;
                overhead.enabled = true;
            }
        }
    }
}
