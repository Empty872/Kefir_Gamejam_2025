using System;
using Charcter;
using Orderer;

namespace DefaultNamespace
{
    public static class UiHelper
    {
        public static string GetAgeDescr(Age age)
        {
            switch (age)
            {
                case Age.Normal:
                    return "cредних лет";
                case Age.Old:
                    return "в преклонном возрасте";
                default:
                    throw new ArgumentOutOfRangeException(nameof(age), age, null);
            }
        }

        public static string GetHairDescr(HairColor hairColor)
        {
            switch (hairColor)
            {
                case HairColor.Black:
                    return "имеет черные волосы";
                case HairColor.Gold:
                    return "имеет русые волосы";
                case HairColor.Red:
                    return "имеет рыжие волосы";
                case HairColor.White:
                    return "имеет белые волосы";
                case HairColor.Nude:
                    return "лысая(ый)";
                default:
                    throw new ArgumentOutOfRangeException(nameof(hairColor), hairColor, null);
            }
        }
        
        public static string GetHatTypeDescr(HatType hatType)
        {
            switch (hatType)
            {
                case HatType.None:
                    return "без головного убора";
                case HatType.Cap:
                    return "носит кепку";
                case HatType.CowboyHat:
                    return "носит широкую шляпу";
                case HatType.Sunglasses:
                    return "носит тёмные очки";
                case HatType.Glasses:
                    return "носит очки";
                default:
                    throw new ArgumentOutOfRangeException(nameof(hatType), hatType, null);
            }
        }
        
        public static string GetHeightDescr(Height height)
        {
            switch (height)
            {
                case Height.Short:
                    return "имеет низкий рост";
                case Height.Medium:
                    return "среднего роста";
                case Height.Tall:
                    return "имеет высокий рост";
                default:
                    throw new ArgumentOutOfRangeException(nameof(height), height, null);
            }
        }
        
        public static string GetSexDescr(Sex sex)
        {
            switch (sex)
            {
                case Sex.Male:
                    return "мужчина";
                case Sex.Female:
                    return "женщина";
                default:
                    throw new ArgumentOutOfRangeException(nameof(sex), sex, null);
            }
        }
        
        public static string GetSkinColor(SkinColor skinColor)
        {
            switch (skinColor)
            {
                case SkinColor.White:
                    return "имеет светлый цвет кожи";
                case SkinColor.Black:
                    return "имеет темнный цвет кожи";
                default:
                    throw new ArgumentOutOfRangeException(nameof(skinColor), skinColor, null);
            }
        }
        
        public static string GetUpperWearColorDescr(WearColor wearColor)
        {
            switch (wearColor)
            {
                case WearColor.White:
                     return "носит куртку белого цвета";
                case WearColor.Black:
                     return "носит куртку черного цвета";
                case WearColor.Brown:
                     return "носит куртку коричневого цвета";
                case WearColor.Green:
                     return "носит куртку зеленого цвета";
                case WearColor.Orange:
                     return "носит куртку оранжевого цвета";
                case WearColor.Red:
                     return "носит куртку красного цвета";
                case WearColor.Yellow:
                     return "носит куртку желтого цвета";
                case WearColor.Blue:
                     return "носит куртку синего цвета";
                case WearColor.Grey:
                     return "носит куртку серого цвета";
                default:
                    throw new ArgumentOutOfRangeException(nameof(wearColor), wearColor, null);
            }
        }
        
        public static string GetLowerWearColorDescr(WearColor wearColor)
        {
            switch (wearColor)
            {
                case WearColor.White:
                    return "носит штаны белого цвета";
                case WearColor.Black:
                    return "носит штаны черного цвета";
                case WearColor.Brown:
                    return "носит штаны коричневого цвета";
                case WearColor.Green:
                    return "носит штаны зеленого цвета";
                case WearColor.Orange:
                    return "носит штаны оранжевого цвета";
                case WearColor.Red:
                    return "носит штаны красного цвета";
                case WearColor.Yellow:
                    return "носит штаны желтого цвета";
                case WearColor.Blue:
                    return "носит штаны синего цвета";
                case WearColor.Grey:
                    return "носит штаны серого цвета";
                default:
                    throw new ArgumentOutOfRangeException(nameof(wearColor), wearColor, null);
            }
        }

        public static string GetOrderedIntStructText(OrderStatementType orderStatementType, int X, int Y)
        {
            switch (orderStatementType)
            {
                case OrderStatementType.AlwaysSaysTrue:
                    return $"Всегда говорит правду";
                case OrderStatementType.AlwaysSaysFalse:
                    return $"Всегда врёт";
                case OrderStatementType.XStatementsIsFalse:
                    return $"{X} из утверждений ложно";
                case OrderStatementType.XStatementsIsTrue:
                    return $"{X} из утверждений истинно";
                case OrderStatementType.Xof3StatementsIsCorrect:
                    return $"как минимум {X} из 3 утверждений истинно";
                case OrderStatementType.NumberXStatementIsFalse:
                    return $"утверждение номер {X+1} ложно";
                case OrderStatementType.NumberXStatementIsTrue:
                    return $"утверждение номер {X+1} истинно";
                case OrderStatementType.None:
                    return $"Количество верных утвеждений не известно";
                default:
                    throw new ArgumentOutOfRangeException(nameof(orderStatementType), orderStatementType, null);
            }
        }

        public static string GetStatementTypeText(StatementType statementType, int x, int y)
        {
            switch (statementType)
            {
                case StatementType.Height:
                    return $"Вместо {GetHeightName((Height)x)} рост указывает {GetHeightName((Height)y)}";
                case StatementType.HairColor:
                    return $"Цвет волос {GetHairName((HairColor)x)} указывает как {GetHairName((HairColor)y)}";
                case StatementType.HatType:
                    return $"Головной убор {GetHatName((HatType)x)} указывает как {GetHatName((HatType)y)}";
                case StatementType.Sex:
                    return $"Вместо {GetSexDescr((Sex)x)} пол будет указан как {GetSexDescr((Sex)y)}";
                case StatementType.LowerColor:
                    return $"{GetColorName((WearColor)x)} цвет штанов указывает как {GetColorName((WearColor)y)}";
                case StatementType.UpperColor:
                    return $"{GetColorName((WearColor)x)} цвет куртки указывает как {GetColorName((WearColor)y)}";
                case StatementType.SkinColor:
                    return $"Если {GetSkinColor((SkinColor)x)}, будет указывано, что {GetSkinColor((SkinColor)y)}";
                case StatementType.Age:
                    return $"Если {GetAgeDescr((Age)x)}, то будет указано, что {GetAgeDescr((Age)y)}";
                default:
                    throw new ArgumentOutOfRangeException(nameof(statementType), statementType, null);
            }
        }
        
        public static string GetColorName(WearColor wearColor)
        {
            switch (wearColor)
            {
                case WearColor.White:
                    return "белый";
                case WearColor.Black:
                    return "черный";
                case WearColor.Brown:
                    return "коричневый";
                case WearColor.Green:
                    return "зеленый";
                case WearColor.Orange:
                    return "оранжевый";
                case WearColor.Red:
                    return "красный";
                case WearColor.Yellow:
                    return "желтый";
                case WearColor.Blue:
                    return "синий";
                case WearColor.Grey:
                    return "серый";
                default:
                    throw new ArgumentOutOfRangeException(nameof(wearColor), wearColor, null);
            }
        }
        
        public static string GetHeightName(Height height)
        {
            switch (height)
            {
                case Height.Short:
                    return "Низкий";
                case Height.Medium:
                    return "Средний";
                case Height.Tall:
                    return "Высокий";
                default:
                    throw new ArgumentOutOfRangeException(nameof(height), height, null);
            }
        }
        
        public static string GetHairName(HairColor hairColor)
        {
            switch (hairColor)
            {
                case HairColor.Black:
                    return "тёмный";
                case HairColor.Gold:
                    return "русый";
                case HairColor.Red:
                    return "рыжий";
                case HairColor.White:
                    return "седой";
                case HairColor.Nude:
                    return "лысый";
                default:
                    throw new ArgumentOutOfRangeException(nameof(hairColor), hairColor, null);
            }
        }
        
        public static string GetHatName(HatType hatType)
        {
            switch (hatType)
            {
                case HatType.None:
                    return "без головного убора";
                case HatType.Cap:
                    return "кепка";
                case HatType.CowboyHat:
                    return "широкая шляпа";
                case HatType.Sunglasses:
                    return "солнечные очки";
                case HatType.Glasses:
                    return "очки";
                default:
                    throw new ArgumentOutOfRangeException(nameof(hatType), hatType, null);
            }
        }

        public static string GetOrderTargetChoseTypeText(OrderTargetChoseType type)
        {
            switch (type)
            {
                case OrderTargetChoseType.OrdererIsRacist:
                    return "Заказчик - расист";
                case OrderTargetChoseType.AlwaysOrderMale:
                    return "Заказывает только мужчин";
                case OrderTargetChoseType.AlwaysOrderFemale:
                    return "Заказывает только женщин";
                case OrderTargetChoseType.AlwaysOrderNoOld:
                    return "Не заказывает стариков";
                case OrderTargetChoseType.Normal:
                    return "";
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }
    }
}