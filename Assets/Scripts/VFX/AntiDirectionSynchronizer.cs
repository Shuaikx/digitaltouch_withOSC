using UnityEngine;
using UnityEngine.VFX;

public class AntiDirectionSynchronizer : MonoBehaviour
{
    private Vector3 _antiDirection;

    [Tooltip("要监控的外部 Transform。")]
    public Transform targetTransform;

    [Tooltip("要控制的 Visual Effect Graph 组件。")]
    public VisualEffect visualEffect;

    [Tooltip("VFX Graph 中触发 Spawn 的自定义事件名称。")]
    public string spawnEventName = "OnPositionChangeSpawn";

    [Tooltip("位置变化的最小阈值。低于此阈值的变化不会触发 Spawn。")]
    public float positionChangeThreshold = 0.01f;

    private Vector3 _previousTargetPosition;

    void Awake()
    {
        if (targetTransform == null)
        {
            Debug.LogError("VFXSpawnOnPositionChange: targetTransform is not assigned!", this);
            enabled = false;
            return;
        }
        if (visualEffect == null)
        {
            Debug.LogError("VFXSpawnOnPositionChange: visualEffect is not assigned!", this);
            enabled = false;
            return;
        }
        _previousTargetPosition = targetTransform.position;
        targetTransform.gameObject.SetActive(false);
    }

    void Update()
    {
        Vector3 currentTargetPosition = targetTransform.position;

        float positionDelta = Vector3.Distance(currentTargetPosition, _previousTargetPosition);
        Vector3 movementDirection = currentTargetPosition - _previousTargetPosition;


        if (positionDelta > positionChangeThreshold)
        {
            visualEffect.SendEvent(spawnEventName);
            Debug.Log("send event");
            targetTransform.gameObject.SetActive(true);
            AntiDirection = -movementDirection.normalized;

            _previousTargetPosition = currentTargetPosition;
        }
        else
        {
            targetTransform.gameObject.SetActive(false);
            AntiDirection = Vector3.zero;
        }
    }

    public Vector3 AntiDirection
    {
        get { return _antiDirection; }
        private set { _antiDirection = value; }
    }
    
    
}