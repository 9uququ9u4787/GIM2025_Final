using UnityEngine;

public class GameStageManager : MonoBehaviour
{
    public int progressStage = 0;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // ȭ�� �߾ӿ��� �������� Ray �߻�
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100f))
            {
                GameObject clicked = hit.collider.gameObject;

                // ? Ŭ���� ������Ʈ �̸� ���
                Debug.Log("? Ŭ���� ������Ʈ: " + clicked.name);

                // ? �ܰ� 0: Radio Ŭ��
                if (progressStage == 0 && clicked.CompareTag("Radio"))
                {
                    Debug.Log("? ������ �׽��ϴ�!");
                    // ���⿡ ���� ���� �̺�Ʈ �߰� ����
                    progressStage = 1;
                }

                // ? �ܰ� 1: MainNPC Ŭ��
                else if (progressStage == 1 && clicked.CompareTag("MainNPC"))
                {
                    Debug.Log("? ���� NPC�� ��ȭ�մϴ�!");
                    // ���⿡ NPC ���� �̺�Ʈ �߰� ����
                    progressStage = 2;
                }

                // ? ������ ������Ʈ Ŭ�� ��: �̸��� ���
                else
                {
                    Debug.Log("?? ���� ��ȣ�ۿ��� �� ���� ������Ʈ�Դϴ�.");
                }
            }
        }
    }
}
