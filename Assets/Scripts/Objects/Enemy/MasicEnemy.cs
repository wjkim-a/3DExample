
public class MasicEnemy : EnemyBase
{
    public void OnTakeMasicDamage(float damage, float weakness)
    {
        OnTakeDamage(damage + weakness);
    }
}
