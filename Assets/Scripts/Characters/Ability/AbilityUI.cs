using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Characters.Ability
{
    public class AbilityUI : MonoBehaviour
    {
        [SerializeField] private Image[] abilityImage;
        public static AbilityUI Instance { get; private set; }
        private void Awake()
        {
            Instance = this;
        }
        public void UseAbility(int index,float cooldown)
        {
            abilityImage[index].fillAmount = 0;
            StartCoroutine(Cooldown(index, cooldown));
        }
        private IEnumerator Cooldown(int index,float cooldown)
        {
            while (abilityImage[index].fillAmount<1)
            {
                abilityImage[index].fillAmount += 0.1f/cooldown;
                yield return new WaitForSecondsRealtime(0.1f);
            }
            yield return null;
        }

    }

}
