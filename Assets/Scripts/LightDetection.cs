using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class LightDetection : MonoBehaviour
{
    public Volume volume;
    private Bloom bloom;
    private ChromaticAberration chromaticAberration;
    private MotionBlur motionBlur;
    GameObject[] transreciever;

    void Start()
    {
        volume.profile.TryGet(out bloom);   
        volume.profile.TryGet(out chromaticAberration);
        volume.profile.TryGet(out motionBlur);
        transreciever = GameObject.FindGameObjectsWithTag("Transreciever");

    }

    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            foreach (var item in transreciever)
            {
                item.GetComponent<MeshRenderer>().enabled = true;
            }
            //bloom.intensity.Override(3000);
            //bloom.scatter.Override(1f);
            chromaticAberration.intensity.Override(1f);
            motionBlur.intensity.Override(0.15f);
        }
        else
        {
            foreach (var item in transreciever)
            {
                item.GetComponent<MeshRenderer>().enabled = false;
            }
            //bloom.intensity.Override(2);
            //bloom.scatter.Override(0f);
            chromaticAberration.intensity.Override(0f);
            motionBlur.intensity.Override(0f);
        }
    }
}
