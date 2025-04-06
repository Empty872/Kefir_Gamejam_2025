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
        private Orderer.Orderer orderer;
        public void Draw(Orderer.Orderer orderer)
        {
            this.orderer = orderer;
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
            
            Aim.Instance.OnCharacterSelected += InstanceOnOnCharacterSelected;
            Aim.Instance.OnCharacterDeselected += InstanceOnOnCharacterDeselected;
        }

        private void InstanceOnOnCharacterDeselected(Person obj)
        {
            statement1.color = Color.white;
            statement2.color = Color.white;
            statement3.color = Color.white;
        }

        private void InstanceOnOnCharacterSelected(Person obj)
        {
            statement1.color = orderer.Statements[0].IsTrueForPerson(obj) ? new Color32(102, 142, 96,255) : new Color32(152, 41 ,36,255); 
            statement2.color = orderer.Statements[1].IsTrueForPerson(obj) ? new Color32(102, 142, 96,255) : new Color32(152 ,41, 36,255);
            statement3.color = orderer.Statements[2].IsTrueForPerson(obj) ? new Color32(102, 142, 96,255) : new Color32(152 ,41 ,36,255);
        }
    }
}