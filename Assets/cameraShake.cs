using UnityEngine;
using System.Collections;
public class cameraShake : MonoBehaviour
{
    private Vector3 originPosition;
    private Quaternion originRotation;
    public float shake_decay;
    public float shake_intensity;
    private Transform _transform;
    /*void OnGUI()
    {
        if (GUI.Button(new Rect(20, 40, 80, 20), "Shake"))
        {
            Shake();
        }
    }*/

       

    void Update()
    {

        Shake();

        if (shake_intensity > 0)
        {
            transform.localPosition = originPosition + Random.insideUnitSphere * shake_intensity;
           /* transform.rotation = new Quaternion(
            originRotation.x + Random.Range(-shake_intensity, shake_intensity) * .2f,
            originRotation.y + Random.Range(-shake_intensity, shake_intensity) * .2f,
            originRotation.z + Random.Range(-shake_intensity, shake_intensity) * .2f,
            originRotation.w + Random.Range(-shake_intensity, shake_intensity) * .2f);*/
            shake_intensity -= shake_decay;
        }

        else
        {
           // Debug.Log("stopped shaking");
            //shaking = false;
            transform.localPosition = originPosition;
            //_transform.localRotation = originRotation;
        }
    
      // if(transform.localPosition.y>0.02 || transform.localPosition.y<-0.02)
       //   {
     //  transform.localPosition.y=0;
     //  }
    
      
    }

    void Shake()
    {
        originPosition = transform.localPosition;
       // originRotation = transform.rotation;
        //shake_intensity = .03f;
      // shake_decay = 0.002f;
    }
}

