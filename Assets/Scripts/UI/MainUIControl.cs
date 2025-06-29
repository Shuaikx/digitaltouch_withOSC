using UnityEngine;
using UnityEngine.Rendering.Universal;

public class MainUIControl : MonoBehaviour
{
    public Camera m_Camera;
    public GameObject bloom;
    private UniversalAdditionalCameraData m_UniversalAdditionalCameraData;

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


    public void DoQuit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
