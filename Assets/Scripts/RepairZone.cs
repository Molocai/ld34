using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RepairZone : MonoBehaviour
{

    // Events
    #region Events
    public delegate void NewZoneFixed();
    public static event NewZoneFixed OnNewZoneFixed;
    #endregion

    public GameManager.ZONEVAISSEAU zone;
    private bool hasAlreadyTriggered = false;

    [Header("Prefabs")]
    public GameObject particlesSparkPrefab;
    public List<GameObject> particlesSmokePrefab;

    private GameObject particleSparkInstance;
    private GameObject particleSmokeInstance;

    [Header("")]
    public GameObject repulseur;

    private Rigidbody2D rbCat;

    public void OnTriggerStay2D(Collider2D collider)
    {
        if (hasAlreadyTriggered)
            return;

        if (collider.gameObject.tag == "Cat")
        {
            Destroy(particleSparkInstance);
            rbCat = collider.gameObject.GetComponent<Rigidbody2D>();
            rbCat.isKinematic = true;

            StartCoroutine(Wait());
            hasAlreadyTriggered = true;
        }

    }

    IEnumerator Wait()
    {
        if (OnNewZoneFixed != null)
            OnNewZoneFixed();

        particleSmokeInstance = (GameObject)Instantiate(particlesSmokePrefab[Random.Range(0, particlesSmokePrefab.Count)], transform.position, transform.rotation);
        particleSmokeInstance.transform.SetParent(transform);
        yield return new WaitForSeconds(2.2f);
        GameManager.Get.DeactivateZone(zone);
    }

    void OnEnable()
    {
        hasAlreadyTriggered = false;

        particleSparkInstance = (GameObject)Instantiate(particlesSparkPrefab, transform.position, transform.rotation);
        particleSparkInstance.transform.SetParent(gameObject.transform);
    }

    void OnDisable()
    {
        Destroy(particleSmokeInstance);
        if (rbCat != null)
            rbCat.isKinematic = false;
        if (GameManager.Get != null)
            GameManager.Get.SelectNewZone();

        if (repulseur != null)
            repulseur.SetActive(true);
    }
}
