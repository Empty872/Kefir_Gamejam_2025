using TMPro;
using UnityEngine;


namespace DefaultNamespace.UI
{
    public class MainUi : MonoBehaviour
    {
        [SerializeField] private OrdererDrawer ordererDrawer1;
        [SerializeField] private OrdererDrawer ordererDrawer2;
        [SerializeField] private AimDrawer aimDrawer;
        [SerializeField] private WindDrawer windDrawer;

        public void DrawUI(Orderer.Orderer orderer1, Orderer.Orderer orderer2)
        {
            ordererDrawer1.Draw(orderer1);
            ordererDrawer2.Draw(orderer2);
            aimDrawer.Init();
            windDrawer.Init();
        }
    }
}