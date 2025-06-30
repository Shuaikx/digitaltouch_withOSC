using UnityEngine;
using Unity.Netcode;
using System;

public class Dual_VFX_UIControl : MonoBehaviour
{
    public BaseVFXControl Flame;

    public BaseVFXControl Particle;
    public BaseVFXControl Teapot;

    public static event Action<bool> OnFlameEnableChange;
    public static event Action<bool> OnTeapotEnableChange;
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

        if (Teapot != null)
        {
            Teapot.enabled = false;
        }
    }

    public void ToggleFlame()
    {
        Flame.enabled = !Flame.enabled;
        OnFlameEnableChange?.Invoke(Flame.enabled);
    }

    public void ToggleTeapot()
    {
        Teapot.enabled = !Teapot.enabled;
        OnTeapotEnableChange?.Invoke(Teapot.enabled);
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
            OnFlameEnableChange?.Invoke(Flame.enabled);
        }
    }
    
    public void SetTeapot(bool state)
    {
        if (Teapot.enabled == state)
        {
            return;
        }
        else
        {
            Teapot.enabled = state;
            OnTeapotEnableChange?.Invoke(Teapot.enabled);
        }
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
            OnParticleEnableChange?.Invoke(Particle.enabled);
        }

    }
}