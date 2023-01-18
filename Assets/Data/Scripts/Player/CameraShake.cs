using UnityEngine;

public class CameraShake : MonoBehaviour
{
    // Transform of the camera to shake. Grabs the gameObject's transform
    // if null.
    private Transform camTransform;

    // How long the object should shake for.
    //public float shakeDuration = 0f;
    private float shakeDuration = 5f;

    // Amplitude of the shake. A larger value shakes the camera harder.
    //public float shakeAmount = 0.7f;
    private float shakeAmount = 0.005f;
    public float decreaseFactor = 1.0f;


    [HideInInspector] public bool _canShake;

    Vector3 originalPos;


    // camera shake for : arrived on floor 1 seg and 0.007
    // for transition 0.003 


    void Awake()
    {
        camTransform = GetComponent<Transform>();

        if (camTransform == null)
        {
            camTransform = GetComponent(typeof(Transform)) as Transform;
        }
    }

    void OnEnable()
    {
        originalPos = camTransform.localPosition;
    }

    void Update()
    {
        if (_canShake) 
        {
            if (shakeDuration > 0)
            {
                camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;

                shakeDuration -= Time.deltaTime * decreaseFactor;
            }
            else
            {
                //shakeDuration = 0f;
                camTransform.localPosition = originalPos;
            }
        }
        /*
        
        */
    }

    public void ShakeCam()
    {
        if (shakeDuration > 0)
        {
            camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;

            shakeDuration -= Time.deltaTime * decreaseFactor;
        }
        else
        {
            shakeDuration = 0f;
            camTransform.localPosition = originalPos;
        }
    }
}
