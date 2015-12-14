using UnityEngine;
using System.Collections;
using System.Collections.Generic;

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
    public static event PlayerGetHit OnPlayerChangeHealth;
    #endregion

    private Rigidbody2D body;
    public PlayerSound ps;

    [Header("Propulseurs")]
    public GameObject topThruster;
    public GameObject bottomThruster;

    [Header("Variables")]
    public float thrusterForce = 1.0f;

    [Range(0, 10f)]
    public int spaceshipMaxHealth = 10;
    [Range(0, 10f)]
    public int spaceshipHealth = 10;

    [Header("Particules")]
    public GameObject deathParticle;

    // Use this for initialization
    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        ps = GetComponent<PlayerSound>();
    }

    void OnEnable()
    {
        GameManager.OnNewZoneActivated += PlayMireilleSound;
        RepairZone.OnNewZoneFixed += FixeZone;
    }

    void PlayMireilleSound()
    {
        ps.Alertes(spaceshipHealth);
    }

    void FixeZone()
    {
        ps.ReparationSoundAleatoire();
        Heal();
    }

    void FixedUpdate()
    {

        if (Input.GetKey(KeyCode.RightArrow))
        {
            body.AddForceAtPosition(transform.TransformDirection(1, 0.5f, 0) * thrusterForce, bottomThruster.transform.position);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            body.AddForceAtPosition(transform.TransformDirection(1, -0.5f, 0) * thrusterForce, topThruster.transform.position);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Asteroid")
        {
            collision.gameObject.GetComponent<AsteroidController>().Explode();
            ps.ImpactAsteroidSound();
            TakeDamage();
        }
    }

    private void TakeDamage()
    {
        spaceshipHealth--;

        // Fire event
        if (OnPlayerChangeHealth != null)
            OnPlayerChangeHealth(spaceshipHealth, spaceshipMaxHealth);

        if (spaceshipHealth <= 0)
            Kill();
    }

    private void Heal()
    {
        if (spaceshipHealth == spaceshipMaxHealth)
            return;

        else
        {
            spaceshipHealth++;

            // Fire event
            if (OnPlayerChangeHealth != null)
                OnPlayerChangeHealth(spaceshipHealth, spaceshipMaxHealth);
        }
    }

    public void Kill()
    {
        Instantiate(deathParticle, transform.position, transform.rotation);
        GameManager.Get.playerIsDead = true;
        Destroy(gameObject);
    }
}
