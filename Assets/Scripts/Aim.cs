using System;
using System.Collections;
using System.Collections.Generic;
using AYellowpaper.SerializedCollections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class Aim : MonoBehaviour
    {
        [SerializeField] private ParticleSystem dustParticleSystem;
        [SerializeField] private int maxAmmoCount;
        private int ammoCount;
        public int AmmoCount => ammoCount;
        [SerializeField] private Environment environment;
        [SerializeField] private Image aimImage;
        [SerializeField] private AudioSource audioSource;
        private Vector3 shootPositionDelta;
        private bool isShooting = false;
        public static Aim Instance;
        private Person currentPerson;
        public event Action OnAmmoCountChanged;
        public event Action<Person> OnCharacterSelected;
        public event Action<Person> OnCharacterDeselected;

        public int MaxAmmoCount => maxAmmoCount;

        private void Awake()
        {
            Instance = this;
            ammoCount = maxAmmoCount;
        }

        private void OnEnable()
        {
            environment.OnChanged += Environment_OnChanged;
        }

        private void Environment_OnChanged(int windSpeed, int distance)
        {
            shootPositionDelta.x = DataHolder.Instance.WindOffsetDictionary[windSpeed];
            shootPositionDelta.y = DataHolder.Instance.DistanceOffsetDictionary[distance];
        }

        private void Update()
        {
            if (!GameController.Instance.IsGameActive)
            {
                return;
            }

            Debug.DrawLine(transform.position + shootPositionDelta, transform.position + transform.forward * 100,
                Color.blue);
            if (Physics.Raycast(transform.position, transform.forward, out var raycastHit)) ;
            {
                var targetTransform = raycastHit.transform;
                if (targetTransform is null)
                {
                    if (currentPerson != null)
                    {
                        OnCharacterDeselected?.Invoke(currentPerson);
                        Debug.Log($"Deselected {currentPerson}");
                        currentPerson = null;
                    }
                }
                else if (targetTransform.TryGetComponent(out Person person))
                {
                    if (currentPerson != person)
                    {
                        OnCharacterSelected?.Invoke(person);
                        Debug.Log($"Selected {person}");
                        if (currentPerson != null)
                        {
                            OnCharacterDeselected?.Invoke(currentPerson);
                            Debug.Log($"Deselected {currentPerson}");
                        }

                        currentPerson = person;
                    }
                }
                else
                {
                    if (currentPerson != null)
                    {
                        OnCharacterDeselected?.Invoke(currentPerson);
                        Debug.Log($"Deselected {currentPerson}");
                        currentPerson = null;
                    }
                }
            }
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Shoot();
            }
        }

        public void Shoot()
        {
            if (ammoCount == 0 || isShooting)
            {
                return;
            }

            isShooting = true;
            ammoCount -= 1;

            OnAmmoCountChanged?.Invoke();
            if (Physics.Raycast(transform.position + shootPositionDelta, transform.forward, out var raycastHit)) ;
            {
                var targetTransform = raycastHit.transform;
                if (targetTransform is null)
                {
                    if (ammoCount == 0)
                        StartCoroutine(DelayCoroutine(3, () => SceneManager.LoadScene(SceneNames.LooseScene)));
                }
                else if (targetTransform.TryGetComponent(out Person person))
                {
                    person.Die();
                }
                else
                {
                    Instantiate(dustParticleSystem.gameObject, raycastHit.point, Quaternion.identity);
                    if (ammoCount == 0)
                        StartCoroutine(DelayCoroutine(3, () => SceneManager.LoadScene(SceneNames.LooseScene)));
                }
            }

            StartCoroutine(ScaleAim());
            audioSource.Play();
        }

        private IEnumerator ScaleAim()
        {
            var startSize = aimImage.rectTransform.sizeDelta.x;
            var increaseTime = 0.12f;
            var decreaseTime = 0.2f;
            while (increaseTime > 0)
            {
                aimImage.rectTransform.sizeDelta *= 1.02f;
                increaseTime -= 0.01f;
                yield return new WaitForSeconds(0.01f);
            }

            var divider = decreaseTime / 0.01f;
            var currentSIze = aimImage.rectTransform.sizeDelta.x;
            var a = currentSIze / startSize;

            var modifier = Math.Pow(a, 1 / divider);
            while (decreaseTime > 0)
            {
                aimImage.rectTransform.sizeDelta /= (float)modifier;
                decreaseTime -= 0.01f;
                yield return new WaitForSeconds(0.01f);
            }

            aimImage.rectTransform.sizeDelta = new Vector2(1920, 1080);
            isShooting = false;
        }
        
        private IEnumerator DelayCoroutine(float waitInSeconds, Action action)
        {
            yield return new WaitForSeconds(waitInSeconds);
            action.Invoke();
        }
    }
}