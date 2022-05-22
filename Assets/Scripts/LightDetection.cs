using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class LightDetection : MonoBehaviour
{
    public Light DirectionalLight;
    public Volume volume;
    private Bloom bloom;
    private ChromaticAberration chromaticAberration;
    private MotionBlur motionBlur;

    void Start()
    {
        volume.profile.TryGet(out bloom);   
        volume.profile.TryGet(out chromaticAberration);
        volume.profile.TryGet(out motionBlur);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            bloom.intensity.Override(3000);
            bloom.scatter.Override(1f);
            DirectionalLight.enabled = false;
            chromaticAberration.intensity.Override(1f);
            motionBlur.intensity.Override(1f);
        }
        else
        {
            bloom.intensity.Override(2);
            bloom.scatter.Override(0f);
            DirectionalLight.enabled = true;
            chromaticAberration.intensity.Override(0f);
            motionBlur.intensity.Override(0.15f);
        }
    }
}
