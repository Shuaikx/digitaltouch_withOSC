using UnityEngine;
using UnityEngine.VFX;

public class TeapotControl : BaseVFXControl 
{
    public VisualEffect Teapot;
    public float baseScale = 0.01f;
    [Tooltip("Sensitivity")]
    public float scaleSensitivity = 0.5f;

    [SerializeField]
    private float interactionRange = 0.5f;

    private Transform teapotTransform;

    protected override void OnEnable()
    {
        base.OnEnable();
        Teapot.enabled = true;
        teapotTransform = Teapot.gameObject.transform;
        Debug.Log("Flame is disabled");
    }

    protected override void OnDisable()
    {
        Teapot.enabled = false;
        teapotTransform = null;
        base.OnDisable();
        Debug.Log("Flame is disabled");

    }

    public override void OnRelationDataUpdated(float distance, Vector3 centerPosition)
    {
        transform.position = centerPosition;

        float targetScale = baseScale + distance * scaleSensitivity;
        transform.localScale = Vector3.one * targetScale;

        float distanceToTeapot = Vector3.Distance(centerPosition, teapotTransform.position);
        

    }
}