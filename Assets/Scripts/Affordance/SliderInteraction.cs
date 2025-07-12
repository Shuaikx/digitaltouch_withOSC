using UnityEngine;

public class SliderInteraction : MonoBehaviour
{
    private Renderer sliderRenderer;
    private Material originalMaterial;
    public Material pushedMaterial; // 拖入一个绿色材质

    private bool isBeingPushed = false;
    private float pushTimer = 0f;
    public float pushDetectionDuration = 0.1f; // 持续被推动多长时间才算被推动

    void Start()
    {
        sliderRenderer = GetComponent<Renderer>();
        if (sliderRenderer != null)
        {
            originalMaterial = sliderRenderer.material; // 保存原始材质
        }
        else
        {
            Debug.LogError("SliderCube 没有 Renderer 组件！", this);
            enabled = false;
        }

        if (pushedMaterial == null)
        {
            Debug.LogError("请为 SliderInteraction 脚本指定一个 Pushed Material (绿色材质)！", this);
            enabled = false;
        }
    }

    void Update()
    {
        // 如果正在被推动，计时器增加
        if (isBeingPushed)
        {
            pushTimer += Time.deltaTime;
            // 如果持续被推动超过一定时间，则显示绿色
            if (pushTimer >= pushDetectionDuration && sliderRenderer.material != pushedMaterial)
            {
                sliderRenderer.material = pushedMaterial;
            }
        }
        else
        {
            // 如果没有被推动，计时器减少，直到为0
            if (pushTimer > 0)
            {
                pushTimer -= Time.deltaTime;
                if (pushTimer <= 0)
                {
                    pushTimer = 0;
                    // 恢复原始颜色
                    if (sliderRenderer.material != originalMaterial)
                    {
                        sliderRenderer.material = originalMaterial;
                    }
                }
            }
        }
        // 每帧重置 isBeingPushed 状态，等待 FixedUpdate 中的碰撞检测再次设置为 true
        isBeingPushed = false;
    }

    // 当有物体持续与滑块接触时调用
    void OnCollisionStay(Collision collision)
    {
        // 检查碰撞的物体是否是 PusherCube
        if (collision.gameObject.CompareTag("Pusher")) // 确保 PusherCube 有 "Pusher" Tag
        {
            isBeingPushed = true;
        }
    }

    // 当物体停止与滑块接触时调用
    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Pusher"))
        {
            // 当推动者离开时，立即开始计时器倒计时，以便恢复颜色
            // pushTimer 会在 Update 中逐渐减少
        }
    }
}