using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private Vector3 lastPosition;
    public float speed;
    public Animator animator;

    void Start()
    {
        lastPosition = transform.position;
        
    }

    void Update()
    {
        // �Ÿ� ��� �� �ӵ� ���ϱ� (float ���ϰ�)
        float distance = Vector3.Distance(transform.position, lastPosition);
        speed = distance / Time.deltaTime;

        // ����� ���
        //Debug.Log("���� �ӵ� (float): " + speed + " units/sec");

        // Animator�� Speed �Ķ���� ����
        animator.SetFloat("Speed", speed);

        // ���� ��ġ ����
        lastPosition = transform.position;
    }
}
