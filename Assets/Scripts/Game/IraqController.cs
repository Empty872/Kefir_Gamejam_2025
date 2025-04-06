using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace Orderer
{
    public class IraqController : MonoBehaviour
    {
        [SerializeField] private List<AudioClip> audioClips;
        [SerializeField] private AudioSource audioSource;
        private int currentIndex;
        [SerializeField] private List<Person> shahids;
        [SerializeField] private IraqTextPrinter iraqTextPrinter;
        private int deathCount;
        public UnityEvent onFirstDeath;
        public UnityEvent onSecondDeath;
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

            PlayAudioClip();
        }

        private void ShahidOnDied()
        {
            DeathCount += 1;
        }

        private void OnFirstDeath()
        {
            iraqTextPrinter.WriteText(
                "Погодные условия изменились. Теперь вы должны брать поправку на ветер. Мы вывели её на ваш супер технологичный прицел, возьмите нужное отклонение по горизонтали и устраните еще одну цель");
            PlayAudioClip();
            Environment.Instance.SetWind(2);
            StartCoroutine(DelayCoroutine(5, () => { onFirstDeath.Invoke(); }));
        }

        private void OnSecondDeath()
        {
            iraqTextPrinter.WriteText(
                "Теперь нужно взять поправку на дальность. Дистанцию до цели мы тоже вывели на ваш супер технологичный прицел. Возьмите поправку по вертикали и устраните следующую цель");
            PlayAudioClip();
            Environment.Instance.SetDistance(150);
            Environment.Instance.SetWind(-1);
            StartCoroutine(DelayCoroutine(5, () => { onSecondDeath.Invoke(); }));
        }

        private void OnThirdDeath()
        {
            iraqTextPrinter.WriteText(
                "Молодец, капрал, теперь ты должен ликвидировать цель в оживленном районе города. С тобой свяжутся и передадут параметры цели. Не всем сведениям можно верить, учти, что наши информаторы очень тупые.");
            PlayAudioClip();
            StartCoroutine(DelayCoroutine(15, () => { SceneManager.LoadScene(SceneNames.GameScene); }));
        }

        private IEnumerator DelayCoroutine(float waitInSeconds, Action action)
        {
            yield return new WaitForSeconds(waitInSeconds);
            action.Invoke();
            PlayerPrefs.SetInt("TutorialCompleted", 1);
        }

        private void PlayAudioClip()
        {
            audioSource.clip = audioClips[currentIndex];
            audioSource.Play();
            currentIndex++;
        }
    }
}