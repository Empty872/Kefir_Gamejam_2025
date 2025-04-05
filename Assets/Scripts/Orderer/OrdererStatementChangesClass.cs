using UnityEngine;

namespace Orderer
{
    [System.Serializable]
    public class OrdererStatementChangesClass
    {
        [SerializeField] private OrdererStatementChanges type;
        [SerializeField] private int xValue;
        [SerializeField] private int yValue;

        public OrdererStatementChanges Type => type;

        public int XValue => xValue;

        public int YValue => yValue;
    }
}