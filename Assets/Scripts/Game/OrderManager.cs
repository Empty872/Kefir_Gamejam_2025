using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

namespace Orderer
{
    public class OrderManager : MonoBehaviour
    {
        [SerializeField] private GameSettings gameSettings;

        private Orderer orderer1;
        private Orderer orderer2;

        public void StartGame(Person person)
        {
            (orderer1, orderer2) = GetCorrectOrderers(person);
            var types = GetRandomStatementTypes(6);
            orderer1.FormStatements(types[0], types[1], types[2], person);
            orderer2.FormStatements(types[2], types[3], types[4], person);
        }

        private (Orderer, Orderer) GetCorrectOrderers(Person person)
        {
            var filteredOrderers = gameSettings.Orderers.Where(x => x.CanChooseTarget(person)).ToList();
            var orderer1 = filteredOrderers[Random.Range(0, filteredOrderers.Count - 1)];
            filteredOrderers.Remove(orderer1);
            var orderer2 = filteredOrderers[Random.Range(0, filteredOrderers.Count - 1)];
            return (orderer1, orderer2);
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