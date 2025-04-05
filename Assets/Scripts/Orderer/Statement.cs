using System;
using Charcter;
using Random = UnityEngine.Random;

namespace Orderer
{
    public class Statement
    {
        private StatementType statementType;
        private int value;

        public StatementType StatementType
        {
            get => statementType;
            set => statementType = value;
        }

        public int Value
        {
            get => value;
            set => this.value = value;
        }

        public Statement(StatementType statementType, int value)
        {
            this.statementType = statementType;
            this.value = value;
        }

        public bool CanApplyChangingType(OrdererStatementChanges changesType, int X)
        {
            switch (changesType)
            {
                case OrdererStatementChanges.AlwaysChangeHairColorXtoY:
                    return statementType == StatementType.HairColor && value == X;
                case OrdererStatementChanges.AlwaysChangeSkinColorXtoY:
                    return statementType == StatementType.SkinColor && value == X;
                case OrdererStatementChanges.AlwaysChangeClothesColorXtoY:
                    return (statementType == StatementType.UpperColor || statementType == StatementType.LowerColor) && value == X;
                case OrdererStatementChanges.AlwaysHigherHeight:
                    return statementType == StatementType.Height;
                case OrdererStatementChanges.AlwaysLowerHeight:
                    return statementType == StatementType.Height;
                case OrdererStatementChanges.None:
                    return true;
                default:
                    return false;
            }
        }
        
        public bool ApplyChangingType(OrdererStatementChanges changesType, int X, int Y)
        {
            switch (changesType)
            {
                case OrdererStatementChanges.AlwaysChangeHairColorXtoY:
                    return statementType == StatementType.HairColor;
                case OrdererStatementChanges.AlwaysChangeSkinColorXtoY:
                    return statementType == StatementType.SkinColor;
                case OrdererStatementChanges.AlwaysChangeClothesColorXtoY:
                    return statementType == StatementType.UpperColor || statementType == StatementType.LowerColor;
                case OrdererStatementChanges.AlwaysHigherHeight:
                    return statementType == StatementType.Height;
                case OrdererStatementChanges.AlwaysLowerHeight:
                    return statementType == StatementType.Height;
                case OrdererStatementChanges.None:
                    return true;
                default:
                    return false;
            }
        }

        public bool IsTrueForPerson(Person person)
        {
            return false;
        }

        public void SetFalse(Person person)
        {
            switch (statementType)
            {
                case StatementType.Height:
                    value = ChangeValueToFalse(0, 2, (int)person.Data.Height);
                    break;
                case StatementType.HairColor:
                    value = ChangeValueToFalse(0, 4, (int)person.Data.HairColor);
                    break;
                case StatementType.HatType:
                    value = ChangeValueToFalse(0, 2, (int)person.Data.HatType);
                    break;
                case StatementType.Sex:
                    value = person.Data.Sex == Sex.Male ? (int)Sex.Female : (int)Sex.Male;
                    break;
                case StatementType.LowerColor:
                    ChangeValueToFalse(0, 7, (int)person.Data.HairColor);
                    break;
                case StatementType.UpperColor:
                    ChangeValueToFalse(0, 7, (int)person.Data.HairColor);
                    break;
                case StatementType.SkinColor:
                    value = person.Data.SkinColor == SkinColor.Black ? (int)SkinColor.White  : (int)SkinColor.Black ;
                    break;
                case StatementType.Age:
                    value = person.Data.Age == Age.Normal ? (int)Age.Old: (int)Age.Normal;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private int ChangeValueToFalse(int start, int end, int value)
        {
            var val = Random.Range(start, end);
            if (val == value)
                val += 1;
            return val;
        }
    }
}