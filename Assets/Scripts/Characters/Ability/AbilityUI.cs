using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Characters.Ability
{
    public class AbilityUI : MonoBehaviour
    {
        [SerializeField] private Image[] abilityImage;
        [SerializeField] private Image castUi;
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
        public void CastUi(float timeCast)
        {
            castUi.fillAmount = 0;
            StartCoroutine(Cast(timeCast));
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
        private IEnumerator Cast(float timeCast)
        {
            while (castUi.fillAmount<1)
            {
                castUi.fillAmount += 0.1f/timeCast;
                yield return new WaitForSecondsRealtime(0.1f);
            }
            castUi.fillAmount = 0;
            yield return null;
        }

    }

}
