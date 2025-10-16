using UnityEngine;

public class PlayerTakeDamageAdapter : MonoBehaviour, ITakeDamageAdapter
{
    private Player _player;

    private void Start()
    {
        _player = GetComponent<Player>();

        if (_player == null)
            gameObject.SetActive(false);
    }

    public void OnTakeDamage(float damage)
    {
        _player?.OnTakeDamage(damage);
    }
}
