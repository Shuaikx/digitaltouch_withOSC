using UnityEngine;
using Unity.Netcode;
using System;

public class Dual_VFX_UIControl : MonoBehaviour
{
    public BaseVFXControl Flame;

    public BaseVFXControl Particle;
    public BaseVFXControl Trails;

    public static event Action<bool> OnFlameEnableChange;
    public static event Action<bool> OnParticleEnableChange;

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
    }

    public void ToggleFlame()
    {
        Flame.enabled = !Flame.enabled;
        OnFlameEnableChange?.Invoke(Flame.enabled);
    }

    public void ToggleParticle()
    {
        Particle.enabled = Particle.enabled;
        OnParticleEnableChange?.Invoke(Particle.enabled);
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
        // OnFlameEnableChange?.Invoke(isFlameEnable);
    }

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
        // OnParticleEnableChange?.Invoke(isParticleEnable);
    }
}