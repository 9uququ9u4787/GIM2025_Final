using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class PlayerDetector : MonoBehaviour
{
    [Header("? 플레이어 감지 시 실행할 이벤트")]
    public UnityEvent onPlayerEnter;

    private void Awake()
    {
        // 트리거 콜라이더인지 확인
        Collider col = GetComponent<Collider>();
        if (!col.isTrigger)
        {
            Debug.LogWarning("?? Collider의 'Is Trigger'가 체크되지 않았습니다. 자동으로 설정합니다.");
            col.isTrigger = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("? 플레이어가 감지되었습니다.");
            onPlayerEnter.Invoke();
        }
    }
}
