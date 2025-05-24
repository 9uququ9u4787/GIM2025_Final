using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider))]
public class PlayerDetector : MonoBehaviour
{
    [Header("? �÷��̾� ���� �� ������ �̺�Ʈ")]
    public UnityEvent onPlayerEnter;

    private void Awake()
    {
        // Ʈ���� �ݶ��̴����� Ȯ��
        Collider col = GetComponent<Collider>();
        if (!col.isTrigger)
        {
            Debug.LogWarning("?? Collider�� 'Is Trigger'�� üũ���� �ʾҽ��ϴ�. �ڵ����� �����մϴ�.");
            col.isTrigger = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("? �÷��̾ �����Ǿ����ϴ�.");
            onPlayerEnter.Invoke();
        }
    }
}
