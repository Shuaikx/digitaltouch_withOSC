using UnityEngine;
using UnityEngine.VFX;

public class VFXPositionBinder : MonoBehaviour
{
    public VisualEffect visualEffect;
    public string positionPropertyName = "EmitterPosition"; 

    void Update()
    {
        if (visualEffect != null)
        {
            visualEffect.SetVector3(positionPropertyName, transform.position);
        }
    }
}