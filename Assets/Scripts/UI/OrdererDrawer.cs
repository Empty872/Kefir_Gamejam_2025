using System.Linq;
using Orderer;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace.UI
{
    public class OrdererDrawer : MonoBehaviour
    {
        [SerializeField] private TMP_Text statement1;
        [SerializeField] private TMP_Text statement2;
        [SerializeField] private TMP_Text statement3;
        [SerializeField] private TMP_Text orderTargetChoseTypeText;
        [SerializeField] private TMP_Text ordererStatementChangesText;
        [SerializeField] private TMP_Text ordererIntStructText;
        [SerializeField] private RectTransform parentRect;
        public void Draw(Orderer.Orderer orderer)
        {
            orderTargetChoseTypeText.text = UiHelper.GetOrderTargetChoseTypeText(orderer.OrderTargetChoseType);
            orderTargetChoseTypeText.gameObject.SetActive(orderer.OrderTargetChoseType != OrderTargetChoseType.Normal);
            
            ordererStatementChangesText.text = UiHelper.GetStatementTypeText(orderer.OrdererStatementChanges.Type,
                orderer.OrdererStatementChanges.XValue,
                orderer.OrdererStatementChanges.YValue);
            ordererStatementChangesText.gameObject.SetActive(orderer.OrdererStatementChanges.XValue !=
                                                             orderer.OrdererStatementChanges.YValue);
            ordererIntStructText.text = UiHelper.GetOrderedIntStructText(orderer.OrdererIntStruct.OrderStatementType,
                orderer.OrdererIntStruct.X,
                orderer.OrdererIntStruct.Y);
            var statements = orderer.Statements.Take(3).ToList();
            statement1.text = statements[0].GetStatementString();
            statement2.text = statements[1].GetStatementString();
            statement3.text = statements[2].GetStatementString();
            
            LayoutRebuilder.ForceRebuildLayoutImmediate(parentRect);
        }
    }
}