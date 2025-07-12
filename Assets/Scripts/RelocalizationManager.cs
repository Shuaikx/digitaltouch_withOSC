using UnityEngine;

public class RelocalizationManager : MonoBehaviour
{
    [SerializeField] private ImageTrackingStablizer m_Stablizer;

    public void StartRelocalization()
    {
        m_Stablizer.IsRelocalizing = true;
    }
}
