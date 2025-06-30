using UnityEngine;
using UnityEngine.VFX;

public class FlameControl : BaseVFXControl 
{
    public VisualEffect Flame1;
    public VisualEffect Flame2;
    [Tooltip("for test")]
    public float FlameEnableRange = 0.1f;

    protected override void OnEnable()
    {
        base.OnEnable();
        Flame1.enabled = true;
        Flame2.enabled = true;
        Debug.Log("Flame is disabled");
    }

    protected override void OnDisable()
    {
        Flame1.enabled = false;
        Flame2.enabled = false;
        base.OnDisable();
        Debug.Log("Flame is disabled");

    }

    public override void OnRelationDataUpdated(float distance, Vector3 centerPosition)
    {
        if (distance <= FlameEnableRange)
        {
            Flame1.Play();
            Flame2.Play();

        }
        else
        {
            Flame1.Stop();
            Flame2.Stop();
        }
    }
}