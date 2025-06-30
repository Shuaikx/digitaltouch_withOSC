using UnityEngine;
using UnityEngine.VFX;

public class CubeVFXControl : MonoBehaviour
{
    public VisualEffect CubeEffect;
    public Transform ControlPoint;

    public Transform HandPoint;

    [SerializeField] private float ControlEnableRange = 0.5f;
    private Vector3 EffectOriginPosition;

    private void Awake()
    {
        EffectOriginPosition = CubeEffect.gameObject.transform.position;
    }

    private void Update()
    {
        var distance = Vector3.Distance(CubeEffect.gameObject.transform.position, HandPoint.position);
        if (distance <= ControlEnableRange)
        {
            ControlPoint.position = HandPoint.position;
        }
        else
        {
            ControlPoint.position = EffectOriginPosition;
        }
    }
}
