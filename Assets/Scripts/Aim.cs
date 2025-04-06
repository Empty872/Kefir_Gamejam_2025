using System.Collections;
using System.Collections.Generic;
using AYellowpaper.SerializedCollections;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class Aim : MonoBehaviour
    {
        [SerializeField] private Environment environment;
        [SerializeField] private Image aimImage;
        [SerializeField] private AudioSource audioSource;
        private Vector3 shootPositionDelta;

        private void OnEnable()
        {
            environment.OnChanged += Environment_OnChanged;
        }

        private void Environment_OnChanged(int windSpeed, int distance)
        {
            Debug.Log(windSpeed);
            Debug.Log(distance);
            shootPositionDelta.x = DataHolder.Instance.WindOffsetDictionary[windSpeed];
            shootPositionDelta.y = DataHolder.Instance.DistanceOffsetDictionary[distance];
        }

        private void Update()
        {
            Debug.DrawLine(transform.position + shootPositionDelta, transform.position + transform.forward * 100,
                Color.blue);

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Shoot();
            }
        }

        public void Shoot()
        {
            if (Physics.Raycast(transform.position + shootPositionDelta, transform.forward, out var raycastHit)) ;
            {
                var targetTransform = raycastHit.transform;
                if (targetTransform is null)
                {
                    Debug.Log("There is no anything");
                }
                else if (targetTransform.TryGetComponent(out Person person))
                {
                    person.Die();
                }
                else
                {
                    Debug.Log("There is no person");
                }
            }
            StartCoroutine(ScaleAim());
            audioSource.Play();
            // enabled = false;
        }

        private IEnumerator ScaleAim()
        {
            var increaseTime = 0.12f;
            var decreaseTime = 0.2f;
            while (increaseTime > 0)
            {
                aimImage.rectTransform.sizeDelta *= 1.02f;
                increaseTime -= 0.01f;
                yield return new WaitForSeconds(0.01f);
            }

            while (decreaseTime > 0)
            {
                aimImage.rectTransform.sizeDelta /= 1.01f;
                decreaseTime -= 0.01f;
                yield return new WaitForSeconds(0.01f);
            }
        }
    }
}