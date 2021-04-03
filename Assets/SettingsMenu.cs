using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsMenu : MonoBehaviour
{
    public void SetFullscreen(bool isFullscreen) {
        Screen.fullScreen = isFullscreen;
    }

    public void SetVSync(bool VSync) {
        if (VSync == true) {
            QualitySettings.vSyncCount = 1;
        } else {
            QualitySettings.vSyncCount = 0;
        }
    }

    public void SetQuality(int qualityIndex) {
        QualitySettings.SetQualityLevel(qualityIndex);
    }
}
