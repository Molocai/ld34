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

    [Header("Zones de réparation")]
    public List<GameObject> repairZones;
    public GameObject activeRepairZone;
    public float minRepairZonePopTime;
    public float maxRepairZonePopTime;
    private bool waitingForZone = false;
    private float nextZonePopTime = 0.0f;
    public GameObject particles;

    // Use this for initialization
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        ps = GetComponent<PlayerSound>();
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

    void Update()
    {
        if (activeRepairZone == null)
        {
            if (!waitingForZone)
            {
                waitingForZone = true;
                nextZonePopTime = Time.time + Random.Range(minRepairZonePopTime, maxRepairZonePopTime);
            }
            else
            {
                if (Time.time >= nextZonePopTime)
                {
                    RandomNewRepairZone();
                    waitingForZone = false;
                }
            }
        }

        if (Input.GetKey(KeyCode.R))
        {
            activeRepairZone = null;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Asteroid")
        {
            GameObject.Destroy(collision.gameObject);
            ps.ImpactAsteroidSound();
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

    private void RandomNewRepairZone()
    {
        // Pick a random zone until we don't have the same as previously
        GameObject zone;

        do
        {
            zone = repairZones[Random.Range(0, repairZones.Count)];
        } while (zone == activeRepairZone);

        activeRepairZone = zone;
        activeRepairZone.SetActive(true);
        ps.Alertes(spaceshipHealth);
    }
}
