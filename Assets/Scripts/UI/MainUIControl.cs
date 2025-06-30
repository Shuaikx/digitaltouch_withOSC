using System.Collections;
//using UnityEditorInternal;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class MainUIControl : MonoBehaviour
{
    public Camera m_Camera;
    public GameObject bloom;
    private UniversalAdditionalCameraData m_UniversalAdditionalCameraData;

    [Tooltip("Main Camera")]
    [SerializeField] private float fadeDuration = 1.0f;
    [SerializeField] private Color backgroundColor = Color.black;

    [SerializeField] private bool isTransparent = true; 
    private Coroutine activeFadeCoroutine;

    private void Awake()
    {
        if (m_Camera == null)
        {
            Debug.LogError("ControlURPCameraPostProcessing: No Camera component found on this GameObject. This script requires a Camera component.", this);
            enabled = false; // Disable the script if no Camera is found
            return;
        }

        m_UniversalAdditionalCameraData = m_Camera.GetUniversalAdditionalCameraData();
        if (m_UniversalAdditionalCameraData == null)
        {
            Debug.LogError("ControlURPCameraPostProcessing: No UniversalAdditionalCameraData found on this Camera. Ensure URP is properly set up and the Camera has this component.", this);
            enabled = false; // Disable the script if no URP camera data is found
            return;
        }

        m_UniversalAdditionalCameraData.renderPostProcessing = false;
        if (bloom != null)
        {
            bloom.SetActive(false);
        }
    }

    private void Start()
    {
        m_Camera.clearFlags = CameraClearFlags.Color;
        m_Camera.backgroundColor = Color.clear;
        isTransparent = true;
    }

    public void TogglePostProcessing()
    {
        if (m_UniversalAdditionalCameraData != null)
        {
            m_UniversalAdditionalCameraData.renderPostProcessing = !m_UniversalAdditionalCameraData.renderPostProcessing;
            Debug.Log($"Post Processing Toggled. Current state: {m_UniversalAdditionalCameraData.renderPostProcessing}");
        }

        if (bloom != null)
        {
            bloom.SetActive(!bloom.activeSelf);
        }
    }
    
    public void SetPostProcessing(bool state)
    {
        if (m_UniversalAdditionalCameraData == state)
        {
            return;
        }
        
        if (m_UniversalAdditionalCameraData != null)
            {
                m_UniversalAdditionalCameraData.renderPostProcessing = !m_UniversalAdditionalCameraData.renderPostProcessing;
                Debug.Log($"Post Processing Toggled. Current state: {m_UniversalAdditionalCameraData.renderPostProcessing}");
            }

        if (bloom != null)
        {
            bloom.SetActive(!bloom.activeSelf);
        }
    }

    public void ToggleHDR()
    {
#if UNITY_HAS_URP
            UniversalRenderPipeline.asset.supportsHDR = !UniversalRenderPipeline.asset.supportsHDR;
            var additionalCameraData = m_Camera.GetUniversalAdditionalCameraData();
            m_Camera.allowHDR = UniversalRenderPipeline.asset.supportsHDR;
            additionalCameraData.allowHDROutput = UniversalRenderPipeline.asset.supportsHDR;
            // UpdateHDRText();
#endif
    }

    public void SetHDR(bool State)
    {
#if UNITY_HAS_URP
        if (UniversalRenderPipeline.asset.supportsHDR == State)
        {
            return;
        }

        UniversalRenderPipeline.asset.supportsHDR = !UniversalRenderPipeline.asset.supportsHDR;
        var additionalCameraData = m_Camera.GetUniversalAdditionalCameraData();
        m_Camera.allowHDR = UniversalRenderPipeline.asset.supportsHDR;
        additionalCameraData.allowHDROutput = UniversalRenderPipeline.asset.supportsHDR;
        // UpdateHDRText();
#endif
    }

    

    public void TogglePassthrough()
    {
        isTransparent = !isTransparent;

        Color targetColor = isTransparent ? Color.clear : backgroundColor;

        if (activeFadeCoroutine != null)
        {
            StopCoroutine(activeFadeCoroutine);
        }

        Debug.Log($"Toggle the passthrough to be {isTransparent}");
        activeFadeCoroutine = StartCoroutine(FadeColorCoroutine(targetColor, fadeDuration));
    }
    public void SetPassthrough(bool state) 
    {
        if (isTransparent == state)
        {
            return;
        }
        isTransparent = !isTransparent;
        Color targetColor = isTransparent ? Color.clear : backgroundColor;

        if (activeFadeCoroutine != null)
        {
            StopCoroutine(activeFadeCoroutine);
        }

        Debug.Log($"Toggle the passthrough to be {isTransparent}");
        activeFadeCoroutine = StartCoroutine(FadeColorCoroutine(targetColor, fadeDuration));
    }

    private IEnumerator FadeColorCoroutine(Color targetColor, float duration)
    {
        Color startingColor = m_Camera.backgroundColor;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / duration);
            m_Camera.backgroundColor = Color.Lerp(startingColor, targetColor, t);
            yield return null;
        }

        m_Camera.backgroundColor = targetColor;
        activeFadeCoroutine = null;
    }

    public void DoQuit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
