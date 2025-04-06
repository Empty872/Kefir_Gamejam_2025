using System;
using Orderer;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace DefaultNamespace.UI
{
    public class HintDrawer : MonoBehaviour
    {
        [SerializeField] private TMP_Text hintText;

        public UnityEvent chosenHint;

        public void ChooseHint(StatementType statementType, Person person)
        {
            var str = "";
            switch (statementType)
            {
                case StatementType.Height:
                    str = $"Подсказка: цель точно {UiHelper.GetHeightDescr(person.Data.Height)}";
                    break;
                case StatementType.HairColor:
                    str = $"Подсказка: wtkm njxyj{UiHelper.GetHairDescr(person.Data.HairColor)}";
                    break;
                case StatementType.HatType:
                    str = $"Подсказка: цель точно {UiHelper.GetHatTypeDescr(person.Data.HatType)}";
                    break;
                case StatementType.Sex:
                    str = $"Подсказка: цель точно {UiHelper.GetSexDescr(person.Data.Sex)}";
                    break;
                case StatementType.LowerColor:
                    str = $"Подсказка: цвет штанов цели точно {UiHelper.GetColorName(person.Data.LowerColor)}";
                    break;
                case StatementType.UpperColor:
                    str = $"Подсказка: цвет верхней одежды цели точно {UiHelper.GetColorName(person.Data.UpperColor)}";
                    break;
                case StatementType.SkinColor:
                    str = $"Подсказка: цель точно {UiHelper.GetSkinColor(person.Data.SkinColor)}";
                    break;
                case StatementType.Age:
                    str = $"Подсказка: цель точно {UiHelper.GetAgeDescr(person.Data.Age)}";
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(statementType), statementType, null);
            }
            chosenHint.Invoke();
            hintText.text = str;
        }
    }
}