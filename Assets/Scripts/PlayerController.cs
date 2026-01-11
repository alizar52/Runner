using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody rb;
    [SerializeField] private float jumpForce = 25.0f;
    [SerializeField] private float gravityModifier = 15f;
    private bool isOnGround = true;
    public bool isGameOver = false;
    private Animator playerAnim;
    [SerializeField] private ParticleSystem explosionParticle;
    [SerializeField] private ParticleSystem dirtParticle;
    [SerializeField] private ParticleSystem dustParticle;

    [SerializeField] private AudioClip jumpSound;
    [SerializeField] private AudioClip crashSound;
    [SerializeField] private AudioClip fireSound; // Звук выстрела
    [SerializeField] private ParticleSystem muzzleFlash; // Эффект вспышки
    private AudioSource playerAudio;

    void Start()
    {
        playerAudio = GetComponent<AudioSource>();
        playerAnim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();

        if (Physics.gravity.y > -9.81f * gravityModifier)
        {
            Physics.gravity *= gravityModifier;
        }
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire") && !isGameOver) // Проверяем нажатие кнопки "Fire"
        {
            OnFire();
        }
    }

    public void OnFire()
    {
        playerAnim.SetTrigger("Handgun_Shoot");
        playerAudio.PlayOneShot(fireSound);
        muzzleFlash.Play();

        // Проверяем попадание
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 100f))
        {
            if (hit.collider.CompareTag("Enemy"))
            {
                hit.collider.GetComponent<Enemy>().TakeDamage();
            }
        }
    }

    public void OnJump()
    {
        if (isOnGround && !isGameOver)
        {
            playerAudio.PlayOneShot(jumpSound, 1.0f);
            dirtParticle.Stop();
            playerAnim.SetTrigger("Jump_trig");
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }
    }

    public void ResetVelocity()
    {
        rb.linearVelocity = Vector3.zero;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            isGameOver = true;

            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);

            explosionParticle.Play();
            playerAudio.PlayOneShot(crashSound, 1.0f);

            dirtParticle.Stop();

            GameManager.instance.GameOver();
        }
        else if (collision.gameObject.CompareTag("Ground"))
        {
            if (!isOnGround)
            {
                dustParticle.Play();
            }
            dirtParticle.Play();
            isOnGround = true;
        }
    }
}
