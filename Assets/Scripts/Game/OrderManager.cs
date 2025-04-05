using System.Collections.Generic;
using System.Linq;
using DefaultNamespace.UI;
using Unity.VisualScripting;
using UnityEngine;

namespace Orderer
{
    public class OrderManager : MonoBehaviour
    {
        private Orderer orderer1 = new ();
        private Orderer orderer2 = new ();
        [SerializeField] private MainUi mainUi;

        public void StartGame(Person person)
        {
            var types = GetRandomStatementTypes(6);
            orderer1.FormStatements(types.Take(3), person);
            orderer2.FormStatements(types.Skip(3), person);
            mainUi.DrawUI(orderer1, orderer2);
        }

        private List<StatementType> GetRandomStatementTypes(int amount)
        {
            var all = new List<StatementType>
            {
                StatementType.Age, StatementType.Height, StatementType.Sex, StatementType.HairColor,
                StatementType.HatType, StatementType.LowerColor, StatementType.SkinColor, StatementType.UpperColor
            };
            if (amount >= all.Count)
                return all;
            var result = new List<StatementType>();
            while (result.Count < amount)
            {
                var element = all[Random.Range(0, all.Count)];
                result.Add(element);
                all.Remove(element);
            }

            return result;
        }
    }
}