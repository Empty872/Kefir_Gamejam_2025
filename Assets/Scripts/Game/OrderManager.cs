using System;
using System.Collections.Generic;
using System.Linq;
using DefaultNamespace.UI;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Orderer
{
    public class OrderManager : MonoBehaviour
    {
        private Orderer orderer1 = new ();
        private Orderer orderer2 = new ();
        private Person person;
        [SerializeField] private MainUi mainUi;
        [SerializeField] private HintDrawer hintDrawer;
        public void StartGame(Person person)
        {
            var types = GetRandomStatementTypes(6);
            orderer1.FormStatements(types.Take(3), person);
            orderer2.FormStatements(types.Skip(3), person);
            mainUi.DrawUI(orderer1, orderer2);
            this.person = person;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                hintDrawer.ChooseHint(StatementType.Height, person);
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                hintDrawer.ChooseHint(StatementType.HairColor, person);
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                hintDrawer.ChooseHint(StatementType.HatType, person);
            }
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                hintDrawer.ChooseHint(StatementType.Sex, person);
            }
            if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                hintDrawer.ChooseHint(StatementType.UpperColor, person);
            }
            if (Input.GetKeyDown(KeyCode.Alpha6))
            {
                hintDrawer.ChooseHint(StatementType.LowerColor, person);
            }
            if (Input.GetKeyDown(KeyCode.Alpha7))
            {
                hintDrawer.ChooseHint(StatementType.SkinColor, person);
            }
            if (Input.GetKeyDown(KeyCode.Alpha8))
            {
                hintDrawer.ChooseHint(StatementType.Age, person);
            }
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