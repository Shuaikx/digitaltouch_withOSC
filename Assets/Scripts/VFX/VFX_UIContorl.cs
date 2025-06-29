using UnityEngine;

public class VFX_UIContorl : MonoBehaviour
{
    public BaseVFXControl_withEvent Flame;

    public BaseVFXControl_withEvent Particle;

    public BaseVFXControl_withEvent Trail;

    // private bool isFlameEnable = false;
    // private bool isParticleEnable = false;
    // private bool isTrailEnable = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void Start()
    {
        if (Flame != null)
        {
            Flame.enabled = false;
        }
        if (Particle != null)
        {
            Particle.enabled = false;
        }
        if (Trail != null)
        {
            Trail.enabled = false;
        }
    }

    public void ToggleFlame()
    {
        Flame.enabled = !Flame.enabled;
    }

    public void ToggleParticle()
    {
        Particle.enabled = !Particle.enabled;
    }

    public void ToggleTrail()
    {
        Trail.enabled = !Trail.enabled;
    }
}
