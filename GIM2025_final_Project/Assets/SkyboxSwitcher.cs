using UnityEngine;

public class SkyboxSwitcher : MonoBehaviour
{
    public Material defaultSkybox; // 기본 Skybox
    public Material graySkybox;    // 회색 Skybox

    private bool isGray = false;

    void Start()
    {
        // 게임 시작 시 현재 Skybox 저장
        if (RenderSettings.skybox != null)
            defaultSkybox = RenderSettings.skybox;

        
    }

    public void SetGraySkybox()
    {
        if (graySkybox != null)
        {
            RenderSettings.skybox = graySkybox;
            DynamicGI.UpdateEnvironment(); // 환경광 업데이트
            isGray = true;
        }
    }

    void OnApplicationQuit()
    {
        // 게임 종료 시 Skybox 원래대로
        RestoreDefaultSkybox();
    }

    void OnDestroy()
    {
        // 씬 종료 또는 오브젝트 파괴 시도
        if (isGray)
            RestoreDefaultSkybox();
    }

    private void RestoreDefaultSkybox()
    {
        if (defaultSkybox != null)
        {
            RenderSettings.skybox = defaultSkybox;
            DynamicGI.UpdateEnvironment();
        }
    }
}
