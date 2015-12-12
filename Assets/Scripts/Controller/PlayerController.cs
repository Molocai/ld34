using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

    // Singleton
    #region Singleton
    static PlayerController _player;
    public static PlayerController Get
    {
        get
        {
            if (_player == null)
                _player = GameObject.FindObjectOfType<PlayerController>();
            return _player;
        }
    }
    #endregion

    // Events
    #region Events
    public delegate void PlayerGetHit(int life, int max);
    public static event PlayerGetHit OnPlayerGetHit;
    #endregion

    private Rigidbody2D body;

    [Header("Propulseurs")]
    public GameObject topThruster;
    public GameObject bottomThruster;

    [Header("Variables")]
    public float thrusterForce = 1.0f;

    [Range(0, 10f)]
    public int spaceshipMaxHealth = 10;
    [Range(0, 10f)]
    public int spaceshipHealth = 10;

    // Use this for initialization
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {

        if (Input.GetKey(KeyCode.UpArrow))
        {
            body.AddForceAtPosition(transform.TransformDirection(1, 0.5f, 0) * thrusterForce, bottomThruster.transform.position);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            body.AddForceAtPosition(transform.TransformDirection(1, -0.5f, 0) * thrusterForce, topThruster.transform.position);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Asteroid")
        {
            TakeDamage();
        }
    }

    private void TakeDamage()
    {
        if (spaceshipHealth - 1 == 0)
        {
            // Die
        }

        else
        {
            spaceshipHealth--;

            // Fire event
            if (OnPlayerGetHit != null)
                OnPlayerGetHit(spaceshipHealth, spaceshipMaxHealth);
        }
    }
}
