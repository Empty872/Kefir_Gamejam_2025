using UnityEngine;

namespace Orderer
{
    [System.Serializable]
    public class OrdererStatementChangesClass
    {
        [SerializeField] private OrdererStatementChanges ordererStatementChanges;
        [SerializeField] private int xValue;
        [SerializeField] private int yValue;

        public OrdererStatementChanges OrdererStatementChanges => ordererStatementChanges;

        public int XValue => xValue;

        public int YValue => yValue;
    }
}