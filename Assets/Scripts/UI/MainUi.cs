using TMPro;
using UnityEngine;


namespace DefaultNamespace.UI
{
    public class MainUi : MonoBehaviour
    {
        [SerializeField] private OrdererDrawer ordererDrawer1;
        [SerializeField] private OrdererDrawer ordererDrawer2;

        public void DrawUI(Orderer.Orderer orderer1, Orderer.Orderer orderer2)
        {
            ordererDrawer1.Draw(orderer1);
            ordererDrawer2.Draw(orderer2);
        }
    }
}