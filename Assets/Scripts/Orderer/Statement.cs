using System;
using Charcter;
using DefaultNamespace;
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

        public bool IsTrueForPerson(Person person)
        {
            switch (statementType)
            {
                case StatementType.Height:
                    return value == (int)person.Data.Height;
                case StatementType.HairColor:
                    return value == (int)person.Data.HairColor;
                case StatementType.HatType:
                    return value == (int)person.Data.HatType;
                case StatementType.Sex:
                    return value == (int)person.Data.Sex;
                case StatementType.LowerColor:
                    return value == (int)person.Data.LowerColor;
                case StatementType.UpperColor:
                    return value == (int)person.Data.UpperColor;
                case StatementType.SkinColor:
                    return value == (int)person.Data.SkinColor;
                case StatementType.Age:
                    return value == (int)person.Data.Age;
                default:
                    throw new ArgumentOutOfRangeException();
            }
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

        public string GetStatementString()
        {
            switch (StatementType)
            {
                case StatementType.Height:
                    return UiHelper.GetHeightDescr((Height)value);
                case StatementType.HairColor:
                    return UiHelper.GetHairDescr((HairColor)value);
                case StatementType.HatType:
                    return UiHelper.GetHatTypeDescr((HatType)value);
                case StatementType.Sex:
                    return UiHelper.GetSexDescr((Sex)value);
                case StatementType.LowerColor:
                    return UiHelper.GetLowerWearColorDescr((WearColor)value);
                case StatementType.UpperColor:
                    return UiHelper.GetUpperWearColorDescr((WearColor)value);
                case StatementType.SkinColor:
                    return UiHelper.GetSkinColor((SkinColor)value);
                case StatementType.Age:
                    return UiHelper.GetAgeDescr((Age)value);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}