using UnityEngine;
using System.Collections;

public class ParticleSystemAutoDestroy : MonoBehaviour {

    public float lifeTime;

    public void Start()
    {
        Destroy(gameObject, lifeTime);
    }
}
