using UnityEngine;
[RequireComponent(typeof(HealthSystem))]
[RequireComponent(typeof(ShootingSystem))]
public class FlyerAI : MonoBehaviour
{
    [Min(0)] public float DetectionRange = 10f;
    public Transform Target;

    // Components Needed
    private HealthSystem HealthSystem;
    private ShootingSystem ShootingSystem;

    private void Awake()
    {
        HealthSystem = GetComponent<HealthSystem>();
        ShootingSystem = GetComponent<ShootingSystem>();
    }
    private void Update()
    {
        if (HealthSystem.IsDead || Target == null)
            return;

        if (Vector3.Distance(transform.position, Target.position) <= DetectionRange)
        {
            transform.LookAt(Target);
            ShootingSystem.Shoot();
        }
    }
}