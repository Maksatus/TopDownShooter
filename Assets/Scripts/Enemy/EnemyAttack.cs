using Health;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private EnemyInfo _enemyInfo;

    private PlayerLives _playerLives;
    public void Attack(Player player)
    {
        _playerLives = player.GetHealthPlayer();
        _playerLives.HitPlayer(_enemyInfo.DamageValue);
    }
    public  void isAtack(bool flag)
    {
        
    }
}
