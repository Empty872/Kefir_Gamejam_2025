using UnityEngine;

namespace Orderer
{
    [System.Serializable]
    public class OrdererIntStruct
    {
        [field: SerializeField] public OrderStatementType OrderStatementType;
        [field: SerializeField] public int X;
        [field: SerializeField] public int Y;
    }
}