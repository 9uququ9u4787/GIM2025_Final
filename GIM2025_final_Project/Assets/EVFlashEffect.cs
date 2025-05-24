using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using System.Collections;

public class EVFlashEffect : MonoBehaviour
{
    [Header("? PostProcess Volume ����")]
    public PostProcessVolume postVolume;

    [Header("?? ����")]
    public float flashValue = -10f;          // ���� ��ο� ���
    public float holdDuration = 1f;          // ��ο� ���� ���� �ð�
    public float recoverDuration = 2f;       // ȸ�� �ð�

    private ColorGrading colorGrading;

    void Start()
    {
        if (postVolume == null)
        {
            Debug.LogError("?? PostProcessVolume�� ������� �ʾҽ��ϴ�!");
            return;
        }

        // �������Ͽ��� ColorGrading ���� ����
        if (!postVolume.profile.TryGetSettings(out colorGrading))
        {
            Debug.LogError("? PostProcess Profile�� ColorGrading�� �����ϴ�!");
        }
    }

    public void TriggerFlash()
    {
        StopAllCoroutines();
        StartCoroutine(FlashRoutine());
    }

    private IEnumerator FlashRoutine()
    {
        if (colorGrading == null) yield break;

        // 1. EV�� -10���� ���� ����
        colorGrading.postExposure.value = flashValue;

        // 2. ������ ���� ���� (1��)
        yield return new WaitForSeconds(holdDuration);

        // 3. EV�� 0���� ������ ȸ�� (2��)
        float elapsed = 0f;
        float startValue = flashValue;

        while (elapsed < recoverDuration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / recoverDuration;
            colorGrading.postExposure.value = Mathf.Lerp(startValue, 0f, t);
            yield return null;
        }

        // 4. ���� ��Ȯ�� 0���� ������
        colorGrading.postExposure.value = 0f;
    }
}
