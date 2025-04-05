using UnityEngine;

namespace Orderer
{
    [System.Serializable]
    public class OrdererStatementChangesClass
    {
        [SerializeField] private StatementType type;
        [SerializeField] private int xValue;
        [SerializeField] private int yValue;

        public StatementType Type
        {
            get => type;
            set => type = value;
        }

        public int XValue
        {
            get => xValue;
            set => xValue = value;
        }

        public int YValue
        {
            get => yValue;
            set => yValue = value;
        }
    }
}