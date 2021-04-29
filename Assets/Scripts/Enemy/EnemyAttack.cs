using Health;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private EnemyInfo enemyInfo;
    [SerializeField] private Animator animator;

    private PlayerLives _playerLives;
    private static readonly int Attack1 = Animator.StringToHash("Attack");
    public void Attack(Player player)
    {
        _playerLives = player.GetHealthPlayer();
        _playerLives.HitPlayer(enemyInfo.DamageValue);
        animator.SetTrigger(Attack1);
    }
}
