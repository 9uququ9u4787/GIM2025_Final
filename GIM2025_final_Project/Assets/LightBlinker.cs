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
        myCollider.enabled = false; // ������ �� ��Ȱ��ȭ
    }

    public void StartBlink()
    {
        if (!spotLight.enabled)
        {
            spotLight.enabled = true; // ���� ���������� �ѱ�
        }

        if (blinkRoutine == null)
        {
            blinkRoutine = StartCoroutine(BlinkLight());
        }

        myCollider.enabled = true; // Ʈ���� �ݶ��̴� �ѱ�
    }

    public void StopBlink()
    {
        if (blinkRoutine != null)
        {
            StopCoroutine(blinkRoutine);
            blinkRoutine = null;
        }

        spotLight.enabled = true; // �׻� ���� ���� ����
        myCollider.enabled = false; // Ʈ���� �ݶ��̴� ����
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
            StopBlink(); // �÷��̾� ������ ������ �ߴ� + �ݶ��̴� ����
        }
    }
}
