using UnityEngine;

public class PoseFreeze : MonoBehaviour
{
    public Animator animator;

    [Header("?? 애니메이션 클립 이름 (Animator의 State 이름과 일치해야 함)")]
    public string animationStateName = "PoseIdle";

    [Header("? 정지시킬 지점 (0 ~ 1 사이)")]
    [Range(0f, 1f)]
    public float normalizedTime = 0.5f; // 애니메이션 중간 프레임

    void Start()
    {
        if (animator == null)
            animator = GetComponent<Animator>();

        FreezePose();
    }

    public void FreezePose()
    {
        if (animator != null && !string.IsNullOrEmpty(animationStateName))
        {
            animator.Play(animationStateName, 0, normalizedTime);
            animator.speed = 0f;

            Debug.Log($"??♂? Animator '{animationStateName}'에서 {normalizedTime * 100f:F0}% 위치에 정지했습니다.");
        }
        else
        {
            Debug.LogWarning("?? Animator 또는 애니메이션 상태 이름이 설정되지 않았습니다.");
        }
    }
}
