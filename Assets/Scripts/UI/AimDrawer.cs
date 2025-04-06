using TMPro;
using UnityEngine;

namespace DefaultNamespace.UI
{
    public class AimDrawer : MonoBehaviour
    {
        [SerializeField] private TMP_Text distanceText;
        [SerializeField] private TMP_Text ammoText;

        public void Start()
        {
            distanceText.text = $"D-{Environment.Instance.Distance}m";
            ammoText.text = $"{Aim.Instance.AmmoCount.ToString()}/{Aim.Instance.MaxAmmoCount.ToString()}";
            Aim.Instance.OnAmmoCountChanged += InstanceOnOnAmmoCountChanged;
            Environment.Instance.OnChanged += InstanceOnOnChanged;
        }

        private void InstanceOnOnChanged(int arg1, int arg2)
        {
            distanceText.text = $"D-{Environment.Instance.Distance}m";
        }

        private void InstanceOnOnAmmoCountChanged()
        {
            ammoText.text = $"{Aim.Instance.AmmoCount.ToString()}/{Aim.Instance.MaxAmmoCount.ToString()}";
        }
    }
}