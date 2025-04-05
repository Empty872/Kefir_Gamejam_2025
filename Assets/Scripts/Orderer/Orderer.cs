using System;
using Charcter;
using UnityEngine;

namespace Orderer
{
    public class Orderer
    {
        [SerializeField] private OrdererData ordererData;
        public bool CanChooseTarget(Person person)
        {
            switch (ordererData.OrderTargetChoseType)
            {
                case OrderTargetChoseType.OrdererIsRacist:
                    return person.Data.SkinColor == SkinColor.Black;
                case OrderTargetChoseType.AlwaysOrderMale:
                    return person.Data.Sex == Sex.Male;
                case OrderTargetChoseType.AlwaysOrderFemale:
                    return person.Data.Sex == Sex.Female;
                case OrderTargetChoseType.AlwaysOrderOld:
                    return person.Data.Age == Age.Old;
                case OrderTargetChoseType.Normal:
                    return true;
                default:
                    return false;
            }
        }

        public void FormStatements(StatementType statement1, StatementType statement2, StatementType statement3, Person person)
        {
            
        }
    }
}