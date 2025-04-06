using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Orderer
{
    public class IraqController : MonoBehaviour
    {
        [SerializeField] private List<Person> shahids;
        [SerializeField] private IraqTextPrinter iraqTextPrinter;
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

        private void Start()
        {
            foreach (var shahid in shahids)
            {
                shahid.Died += ShahidOnDied;
            }
            Environment.Instance.SetWind(0);
            Environment.Instance.SetDistance(50);
        }

        private void ShahidOnDied()
        {
            DeathCount += 1;
        }

        private void OnFirstDeath()
        {
            Environment.Instance.SetWind(2);
            iraqTextPrinter.WriteText("Погодные условия изменились. Теперь вы должны брать поправку на ветер. Мы вывели её на ваш супер технологичный прицел, возьмите нужное отклонение по горизонтали и устраните еще одну цель");
            onFirstDeath.Invoke();
        }

        private void OnSecondDeath()
        {
            Environment.Instance.SetDistance(150);
            iraqTextPrinter.WriteText("Теперь нужно взять поправку на дальность. Дистанцию до цели мы тоже вывели на ваш супер технологичный прицел. Возьмите поправку по вертикали и устраните следующую цель");
            onSecondDeath.Invoke();
        }

        private void OnThirdDeath()
        {
            iraqTextPrinter.WriteText("Молодец, капрал, теперь ты должен ликвидировать цель в оживленном районе города. С тобой свяжутся и передадут параметры цели. Не всем сведениям можно верить, учти, что наши информаторы очень тупые.");
            onThirdDeath.Invoke();
        }
    }
}