using System;
using Orderer;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Charcter
{
    public class PersonData : ScriptableObject
    {
        [SerializeField] private Height height;
        [SerializeField] private HairColor hairColor;
        [SerializeField] private HatType hatType;
        [SerializeField] private Sex sex;
        [SerializeField] private WearColor upperColor;
        [SerializeField] private WearColor lowerColor;
        [SerializeField] private SkinColor skinColor;
        [SerializeField] private Age age;

        public Height Height => height;

        public HairColor HairColor => hairColor;

        public HatType HatType => hatType;

        public Sex Sex => sex;

        public WearColor UpperColor => upperColor;

        public WearColor LowerColor => lowerColor;

        public SkinColor SkinColor => skinColor;

        public Age Age => age;

        public int GetStatementValue(StatementType value)
        {
            switch (value)
            {
                case StatementType.Height:
                    return (int)height;
                case StatementType.HairColor:
                    return (int)hairColor;
                case StatementType.HatType:
                    return (int)hatType;
                case StatementType.Sex:
                    return (int)sex;
                case StatementType.LowerColor:
                    return (int)lowerColor;
                case StatementType.UpperColor:
                    return (int)upperColor;
                case StatementType.SkinColor:
                    return (int)skinColor;
                case StatementType.Age:
                    return (int)age;
                default:
                    return 0;
            }
        }
        
        public int GetFalseStatementValue(StatementType value)
        {
            switch (value)
            {
                case StatementType.Height:
                    return GetRandomNumber(3, (int)height);
                case StatementType.HairColor:
                    return GetRandomNumber(5, (int)hairColor);
                case StatementType.HatType:
                    return GetRandomNumber(3, (int)hairColor);
                case StatementType.Sex:
                    return ((int)sex + 1)%2;
                case StatementType.LowerColor:
                    return GetRandomNumber(8, (int)hairColor);
                case StatementType.UpperColor:
                    return GetRandomNumber(8, (int)hairColor);
                case StatementType.SkinColor:
                    return ((int)skinColor + 1)%2;
                case StatementType.Age:
                    return ((int)age + 1)%2;
                default:
                    return 0;
            }
        }

        private int GetRandomNumber(int length, int value)
        {
            var randomValue3 = Random.Range(0, length);
            if (randomValue3 == value)
                randomValue3 += Random.Range(0, length - 1);
            return randomValue3;
        }
    }
}