using UnityEngine;

[ExecuteInEditMode]
public class ME_ParticleGravityPoint : MonoBehaviour
{
    public Transform target; // 타겟 Transform
    public float Force = 1; // 중력 세기
    public bool DistanceRelative; // 거리 비례 여부
    private ParticleSystem ps;
    private ParticleSystem.Particle[] particles;

    private ParticleSystem.MainModule mainModule;
    private Vector3 prevPos;

    void Start()
    {
        ps = GetComponent<ParticleSystem>();
        mainModule = ps.main;

        // 타겟이 없다면 바닥 방향(밑으로) 타겟 생성
        if (target == null)
        {
            GameObject groundTarget = new GameObject("GroundTarget");
            target = groundTarget.transform;
            target.position = transform.position + Vector3.down * 10f; // 초기 바닥 위치 설정
        }
    }

    void LateUpdate()
    {
        var maxParticles = mainModule.maxParticles;
        if (particles == null || particles.Length < maxParticles)
        {
            particles = new ParticleSystem.Particle[maxParticles];
        }
        int particleCount = ps.GetParticles(particles);

        var targetTransformedPosition = Vector3.zero;

        // 타겟 위치를 계속 갱신하여 바닥 방향으로 설정
        if (mainModule.simulationSpace == ParticleSystemSimulationSpace.Local)
        {
            targetTransformedPosition = transform.InverseTransformPoint(target.position);
        }
        else if (mainModule.simulationSpace == ParticleSystemSimulationSpace.World)
        {
            target.position = transform.position + Vector3.down * 10f; // 항상 바닥 방향
            targetTransformedPosition = target.position;
        }

        float forceDeltaTime = Time.deltaTime * Force;
        if (DistanceRelative)
            forceDeltaTime *= Mathf.Abs((prevPos - targetTransformedPosition).magnitude);

        for (int i = 0; i < particleCount; i++)
        {
            var distanceToParticle = targetTransformedPosition - particles[i].position;
            var directionToTarget = Vector3.Normalize(distanceToParticle);

            var seekForce = directionToTarget * forceDeltaTime;

            particles[i].velocity += seekForce; // 속도에 힘 적용
        }

        ps.SetParticles(particles, particleCount);
        prevPos = targetTransformedPosition;
    }
}
