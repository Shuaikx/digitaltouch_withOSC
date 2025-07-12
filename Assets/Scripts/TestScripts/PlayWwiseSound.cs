using UnityEngine;
using UnityEngine.UI; // 引入 UI 命名空间
using AK.Wwise;
using System;
using Unity.Android.Gradle.Manifest; // 引入 Wwise 命名空间

public class PlayWwiseSound : MonoBehaviour
{
    public AK.Wwise.Event myWwiseEvent;

    public Button playButton;

    private uint bankID;

    void Start()
    {
        if (myWwiseEvent == null)
        {
            Debug.LogError("Wwise Event is not assigned! Please assign it in the Inspector.");
            return;
        }

        if (playButton == null)
        {
            Debug.LogError("Play Button is not assigned! Please assign it in the Inspector.");
            return;
        }

        playButton.onClick.AddListener(PlaySound);

        AkUnitySoundEngine.LoadBank("Test_SoundBank", out bankID);
        Debug.Log("SoundBank 'Main_SoundBank' loaded.");
    }

    // 当按钮被点击时调用的方法
    public void PlaySound()
    {
        if (myWwiseEvent != null)
        {
            myWwiseEvent.Post(gameObject); // 将声音发布到此 GameObject 上
            Debug.Log("Playing Wwise Event: " + myWwiseEvent.Name);
        }
    }

    void OnDestroy()
    {
        if (playButton != null)
        {
            playButton.onClick.RemoveListener(PlaySound);
        }

        AkUnitySoundEngine.UnloadBank("Test_SoundBank", IntPtr.Zero, bankID);
        Debug.Log("SoundBank 'Main_SoundBank' unloaded.");
    }
}