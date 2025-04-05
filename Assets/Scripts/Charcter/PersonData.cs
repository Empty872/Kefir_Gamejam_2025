using UnityEngine;

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
    }
}