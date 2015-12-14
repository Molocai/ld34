using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

    // Singleton
    #region Singleton
    static GameManager _manager;
    public static GameManager Get
    {
        get
        {
            if (_manager == null)
                _manager = GameObject.FindObjectOfType<GameManager>();
            return _manager;
        }
    }
    #endregion

    public bool playerIsDead = false;
    public float score;
    public string formatedScore = "";
    private float currentTime;

    public enum ZONEVAISSEAU {
        COCKPIT,
        NEZ,
        BAS,
        ARRIERE
    }

    public Dictionary<ZONEVAISSEAU, GameObject> availableZones;
    [Header("Cockpit, nez, bas, arrière")]
    public List<GameObject> zonesOnShip;

    private ZONEVAISSEAU lastActivatedZone;

    void Update()
    {
        if (!playerIsDead)
        {
            score = Time.time - currentTime;
            formatedScore = string.Format("{0:00.00}", score);
        }
    }

	// Use this for initialization
	void Start () {
        currentTime = Time.time;
        availableZones = new Dictionary<ZONEVAISSEAU, GameObject>();

	    foreach(GameObject go in zonesOnShip)
        {
            availableZones.Add(go.GetComponent<RepairZone>().zone, go);
        }

        ActivateZone(ZONEVAISSEAU.COCKPIT);
        lastActivatedZone = ZONEVAISSEAU.COCKPIT;
    }

    public void ActivateZone(ZONEVAISSEAU zone)
    {
        availableZones[zone].SetActive(true);

        PlayerController.Get.PlayMireilleSound();
    }

    public void DeactivateZone(ZONEVAISSEAU zone)
    {
        availableZones[zone].SetActive(false);
        lastActivatedZone = zone;
    }

    public ZONEVAISSEAU GetRandomZone()
    {
        ZONEVAISSEAU tmp;
        do
        {
            tmp = (ZONEVAISSEAU)Random.Range(0, 4);
        } while (tmp == lastActivatedZone);

        return tmp;
    }

    public void SelectNewZone()
    {
        StartCoroutine(WaitAndNewZone(2.0f));
    }

    IEnumerator WaitAndNewZone(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        ActivateZone(GetRandomZone());
    }
}
