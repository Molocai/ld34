using UnityEngine;
using System.Collections;

public class NovaVolume : MonoBehaviour
{
    public Transform otherSource;
    private Transform player;
    private AudioSource mAudioSource;
    private float distPlayer, distOther, distOtherPlayer;

    void Start()
    {
        player = PlayerController.Get.transform;
        mAudioSource = GetComponent<AudioSource>();
    }
	void Update ()
    {
        distPlayer = Mathf.Abs(player.position.x - transform.position.x);
        distOther = Mathf.Abs(otherSource.position.x - transform.position.x);
        distOtherPlayer = Mathf.Abs(otherSource.position.x - player.transform.position.x);
        
        if (distOtherPlayer >= distOther && distOtherPlayer > distPlayer)
            mAudioSource.volume = 1;
        else mAudioSource.volume = 1 - (distPlayer / distOther);

        //Debug.Log("dist player = " + distPlayer.ToString() + " dist other = " + distOther.ToString() + " vol = " + mAudioSource.volume);//(1 - (distPlayer / distOther)).ToString());
    }
}
