using UnityEngine;

namespace Characters.Ability
{
    public class AbilitySystem : MonoBehaviour
    {
        [SerializeField] private MagicInfo[] magicInfo;

        private static readonly int Speed = Animator.StringToHash("Speed");
        private static readonly int LightAttack = Animator.StringToHash("LightAttack");
        private static readonly int BlackHole = Animator.StringToHash("BlackHole");
        private static readonly int Flame = Animator.StringToHash("Flame");

        private float[] _timeToFire;
        private Player _player;
        private AbilityUI _abilityUI;

        private void Start()
        {
            _player = Player.Instance;
            _abilityUI = AbilityUI.Instance;;
            _timeToFire = new float[magicInfo.Length];
        }
        private void Update()
        { 
            Cast();
            MoveCharacter();
        }
        private void Cast()
        {
            if (Input.GetMouseButtonDown(1) && Time.time >= _timeToFire[0])
            {
                _timeToFire[0] = Time.time + magicInfo[0].FireRate;
                _player.GetAnimator().SetTrigger(LightAttack);
                _abilityUI.CastUi(magicInfo[0].TimeCast);
                _abilityUI.UseAbility(0,magicInfo[0].FireRate);
                _player.GetCastMagic().ShootProjectile(magicInfo[0]);
            }
            else if (Input.GetKeyDown(KeyCode.Q) && Time.time >= _timeToFire[1])
            {
                _timeToFire[1] = Time.time + magicInfo[1].FireRate;
                _player.GetNavMeshAgent().isStopped = true;
                _player.GetAnimator().SetTrigger(BlackHole);
                _abilityUI.CastUi(magicInfo[1].TimeCast);
                _abilityUI.UseAbility(1,magicInfo[1].FireRate);
                _player.GetCastMagic().ShootProjectile(magicInfo[1]);
            }
        }
        private void MoveCharacter()
        {
            _player.GetAnimator().SetFloat(Speed,_player.GetNavMeshAgent().velocity.magnitude);
        }
    }
}

