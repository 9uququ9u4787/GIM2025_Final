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
        // 거리 계산 후 속도 구하기 (float 단일값)
        float distance = Vector3.Distance(transform.position, lastPosition);
        speed = distance / Time.deltaTime;

        // 디버그 출력
        //Debug.Log("현재 속도 (float): " + speed + " units/sec");

        // Animator에 Speed 파라미터 연동
        animator.SetFloat("Speed", speed);

        // 현재 위치 갱신
        lastPosition = transform.position;
    }
}
