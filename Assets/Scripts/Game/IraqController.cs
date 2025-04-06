using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Orderer
{
    public class IraqController : MonoBehaviour
    {
        [SerializeField] private List<Person> shahids;
        private int deathCount;
        public UnityEvent onFirstDeath;
        public UnityEvent onSecondDeath;
        public UnityEvent onThirdDeath;
        public int DeathCount
        {
            get => deathCount;
            set
            {
                deathCount = value;
                switch (deathCount)
                {
                    case 1:
                        OnFirstDeath();
                        break;
                    case 2:
                        OnSecondDeath();
                        break;
                    case 3:
                        OnThirdDeath();
                        break;
                }
            }
        }

        private void Awake()
        {
            foreach (var shahid in shahids)
            {
                shahid.Died += ShahidOnDied;
            }
        }

        private void ShahidOnDied()
        {
            DeathCount += 1;
        }

        private void OnFirstDeath()
        {
            Environment.Instance.SetWind(2);
            onFirstDeath.Invoke();
        }

        private void OnSecondDeath()
        {
            Environment.Instance.SetDistance(150);
            onSecondDeath.Invoke();
        }

        private void OnThirdDeath()
        {
            onThirdDeath.Invoke();
        }
    }
}