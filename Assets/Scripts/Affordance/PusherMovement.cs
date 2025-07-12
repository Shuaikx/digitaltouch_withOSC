using UnityEngine;

public class PusherMovement : MonoBehaviour
{
    public float movementSpeed = 1f; // 推动者移动速度
    public float movementRange = 0.5f; // 推动者在 Z 轴上的往返范围
    private Vector3 startPosition;
    private int direction = 1; // 1: forward, -1: backward

    void Start()
    {
        startPosition = transform.position;
    }

    void FixedUpdate() // 使用 FixedUpdate 处理 Rigidbody 的移动
    {
        // 计算新的 Z 轴位置
        float newZ = startPosition.z + Mathf.Sin(Time.time * movementSpeed) * movementRange;

        // 设置 Rigidbody 的位置 (对于 Kinematic Rigidbody)
        // 使用 MovePosition 而不是直接修改 transform.position，以确保物理引擎正确处理碰撞
        GetComponent<Rigidbody>().MovePosition(new Vector3(transform.position.x, transform.position.y, newZ));
    }
}