using System.Collections.Generic;
using AYellowpaper.SerializedCollections;
using UnityEngine;

namespace Orderer
{
    [CreateAssetMenu(menuName = "ScriptalbeObjects/OrdererData")]
    public class OrdererData : ScriptableObject
    {
        [SerializeField] private OrderTargetChoseType orderTargetChoseType;
        [SerializeField] private OrdererStatementChangesClass ordererStatementChanges;
        [SerializeField] private OrdererIntStruct ordererIntStruct;

        public OrderTargetChoseType OrderTargetChoseType => orderTargetChoseType;

        public OrdererStatementChangesClass OrdererStatementChanges => ordererStatementChanges;

        public OrdererIntStruct OrdererIntStruct => ordererIntStruct;
    }
}