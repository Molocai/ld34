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
    public static event PlayerGetHit OnPlayerGetHit;
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

    // Use this for initialization
    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        ps = GetComponent<PlayerSound>();
    }

    void OnEnable()
    {
        GameManager.OnNewZoneActivated += PlayMireilleSound;
        RepairZone.OnNewZoneFixed += PlayFixingSound;
    }

    void PlayMireilleSound()
    {
        ps.Alertes(spaceshipHealth);
    }

    void PlayFixingSound()
    {
        ps.ReparationSoundAleatoire();
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
        if (spaceshipHealth - 1 == 0)
        {
            // TODO: Die
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
