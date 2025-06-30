using UnityEngine;

public class VFX_UIContorl : MonoBehaviour
{
    public BaseVFXControl_withEvent Flame;

    public BaseVFXControl_withEvent Particle;

    public BaseVFXControl_withEvent Trail;

    

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

    public void SetFlame(bool state)
    {
        if (Flame.enabled == state)
        {
            return;
        }
        else
        {
            Flame.enabled = state;
        }
    }
    
    // public void SetTeapot(bool state)
    // {
    //     if (Teapot.enabled == state)
    //     {
    //         return;
    //     }
    //     else
    //     {
    //         Teapot.enabled = state;
    //     }
    // }

    public void SetParticle(bool state)
    {
        if (Particle.enabled == state)
        {
            return;
        }
        else
        {
            Particle.enabled = state;
        }

    }
}
