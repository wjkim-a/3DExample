
public class PhysicsEnemy : EnemyBase
{
    public void OnTakePhysicsDamage(float damage, float defense)
    {
        OnTakeDamage(damage - defense);
    }
}
