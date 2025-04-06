using TMPro;
using UnityEngine;

namespace DefaultNamespace.UI
{
    public class AimDrawer : MonoBehaviour
    {
        [SerializeField] private TMP_Text distanceText;
        [SerializeField] private TMP_Text ammoText;

        public void Init()
        {
            distanceText.text = $"D -- {Environment.Instance.Distance}";
            ammoText.text = $"{Aim.Instance.AmmoCount.ToString()}/{Aim.Instance.MaxAmmoCount.ToString()}";
            Aim.Instance.OnAmmoCountChanged += InstanceOnOnAmmoCountChanged;
        }

        private void InstanceOnOnAmmoCountChanged()
        {
            ammoText.text = $"{Aim.Instance.AmmoCount.ToString()}/{Aim.Instance.MaxAmmoCount.ToString()}";
        }
    }
}