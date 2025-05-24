using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using System.Collections;

public class EVFlashEffect : MonoBehaviour
{
    [Header("? PostProcess Volume 연결")]
    public PostProcessVolume postVolume;

    [Header("?? 설정")]
    public float flashValue = -10f;          // 순간 어두운 밝기
    public float holdDuration = 1f;          // 어두운 상태 유지 시간
    public float recoverDuration = 2f;       // 회복 시간

    private ColorGrading colorGrading;

    void Start()
    {
        if (postVolume == null)
        {
            Debug.LogError("?? PostProcessVolume이 연결되지 않았습니다!");
            return;
        }

        // 프로파일에서 ColorGrading 설정 추출
        if (!postVolume.profile.TryGetSettings(out colorGrading))
        {
            Debug.LogError("? PostProcess Profile에 ColorGrading이 없습니다!");
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

        // 1. EV를 -10으로 순간 변경
        colorGrading.postExposure.value = flashValue;

        // 2. 깜깜한 상태 유지 (1초)
        yield return new WaitForSeconds(holdDuration);

        // 3. EV를 0으로 서서히 회복 (2초)
        float elapsed = 0f;
        float startValue = flashValue;

        while (elapsed < recoverDuration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / recoverDuration;
            colorGrading.postExposure.value = Mathf.Lerp(startValue, 0f, t);
            yield return null;
        }

        // 4. 보정 정확히 0으로 마무리
        colorGrading.postExposure.value = 0f;
    }
}
