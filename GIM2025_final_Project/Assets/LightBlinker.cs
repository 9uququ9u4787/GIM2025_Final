using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]
public class LightBlinker : MonoBehaviour
{
    public Light spotLight;
    public float intervalMin = 0.05f;
    public float intervalMax = 0.3f;

    private Coroutine blinkRoutine;
    private Collider myCollider;

    void Start()
    {
        if (spotLight == null)
            spotLight = GetComponent<Light>();

        myCollider = GetComponent<Collider>();
        myCollider.enabled = false; // 시작할 때 비활성화
    }

    public void StartBlink()
    {
        if (!spotLight.enabled)
        {
            spotLight.enabled = true; // 불이 꺼져있으면 켜기
        }

        if (blinkRoutine == null)
        {
            blinkRoutine = StartCoroutine(BlinkLight());
        }

        myCollider.enabled = true; // 트리거 콜라이더 켜기
    }

    public void StopBlink()
    {
        if (blinkRoutine != null)
        {
            StopCoroutine(blinkRoutine);
            blinkRoutine = null;
        }

        spotLight.enabled = true; // 항상 켜진 상태 유지
        myCollider.enabled = false; // 트리거 콜라이더 끄기
    }

    IEnumerator BlinkLight()
    {
        while (true)
        {
            spotLight.enabled = !spotLight.enabled;
            yield return new WaitForSeconds(Random.Range(intervalMin, intervalMax));
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StopBlink(); // 플레이어 들어오면 깜빡임 중단 + 콜라이더 꺼짐
        }
    }
}
