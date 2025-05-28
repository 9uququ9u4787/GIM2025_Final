using UnityEngine;

public class SkyboxSwitcher : MonoBehaviour
{
    public Material defaultSkybox; // �⺻ Skybox
    public Material graySkybox;    // ȸ�� Skybox

    private bool isGray = false;

    void Start()
    {
        // ���� ���� �� ���� Skybox ����
        if (RenderSettings.skybox != null)
            defaultSkybox = RenderSettings.skybox;

        
    }

    public void SetGraySkybox()
    {
        if (graySkybox != null)
        {
            RenderSettings.skybox = graySkybox;
            DynamicGI.UpdateEnvironment(); // ȯ�汤 ������Ʈ
            isGray = true;
        }
    }

    void OnApplicationQuit()
    {
        // ���� ���� �� Skybox �������
        RestoreDefaultSkybox();
    }

    void OnDestroy()
    {
        // �� ���� �Ǵ� ������Ʈ �ı� �õ�
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
