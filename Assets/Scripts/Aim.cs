using System.Collections.Generic;
using AYellowpaper.SerializedCollections;
using UnityEngine;

namespace DefaultNamespace
{
    public class Aim : MonoBehaviour
    {
        [SerializeField] private Environment environment;
        private Vector3 shootPositionDelta;

        private void OnEnable()
        {
            environment.OnChanged += Environment_OnChanged;
        }

        private void Environment_OnChanged(int windSpeed, int distance)
        {
            Debug.Log(windSpeed);
            shootPositionDelta.x = DataHolder.Instance.PossibleWindSpeeds[windSpeed];
            shootPositionDelta.y = DataHolder.Instance.PossibleDistances[distance];
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
            Debug.Log(shootPositionDelta + transform.position);
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
        }
    }
}