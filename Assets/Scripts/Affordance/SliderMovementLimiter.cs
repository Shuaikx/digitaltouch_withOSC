using UnityEngine;

public class SliderMovementLimiter : MonoBehaviour
{
    [Header("滑动范围设置")]
    public Transform sliderTrack; // 拖入 SliderTrack 物体
    public float sliderHalfLength = 0.1f; // 滑块自身长度的一半 (0.2 / 2 = 0.1)

    private float minZ;
    private float maxZ;

    void Start()
    {
        if (sliderTrack == null)
        {
            Debug.LogError("请将 SliderTrack 物体拖入到 SliderMovementLimiter 脚本的 sliderTrack 字段中！", this);
            enabled = false; // 禁用脚本
            return;
        }

        // 计算滑块运动范围的 Z 轴边界
        // SliderTrack 的 Z 轴长度是 1，中心点在 (0,0,0)
        // 所以其 Z 轴范围是 -0.5 到 0.5
        // 滑块的中心点在 SliderTrack 的 Z 轴范围内移动
        // 考虑到滑块自身的长度，其边缘不能超出轨道边缘
        float trackHalfLength = sliderTrack.localScale.z / 2f; // SliderTrack 的半长
        float trackCenterZ = sliderTrack.position.z; // SliderTrack 的中心 Z 坐标

        minZ = trackCenterZ - trackHalfLength + sliderHalfLength;
        maxZ = trackCenterZ + trackHalfLength - sliderHalfLength;

        // 确保滑块初始位置在范围内
        Vector3 currentPos = transform.position;
        currentPos.z = Mathf.Clamp(currentPos.z, minZ, maxZ);
        transform.position = currentPos;
    }

    void LateUpdate()
    {
        // 限制滑块的 Z 轴位置
        Vector3 currentPos = transform.position;
        currentPos.z = Mathf.Clamp(currentPos.z, minZ, maxZ);
        transform.position = currentPos;
    }
}