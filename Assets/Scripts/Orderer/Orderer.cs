using System;
using System.Collections.Generic;
using System.Linq;
using Charcter;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Orderer
{
    public class Orderer : MonoBehaviour
    {
        private OrderTargetChoseType orderTargetChoseType;
        private OrdererStatementChangesClass ordererStatementChanges;
        private OrdererIntStruct ordererIntStruct;
        private List<Statement> statements;

        private void Awake()
        {
            statements = new List<Statement>();
        }
        
        public void FormStatements(IEnumerable<StatementType> statementTypes, Person person)
        {
            statements.Clear();
            foreach (var statement in statementTypes)
            {
                statements.Add(GetTrueFalseStatement(statement, person, 0.5f));
            }
            FillTargetChooseType(statements, person);
            FillOrdererStatementChanges(statements, person);
            FillOrdererIntStruct(statements, person);
        }

        private Statement GetTrueFalseStatement(StatementType statementType, Person person, float probabilityTrue)
        {
            return new Statement(statementType, person.GetTrueFalseStatementValue(probabilityTrue,statementType));
        }

        private void FillTargetChooseType(IList<Statement> statements, Person person)
        {
            foreach (var statement in statements)
            {
                switch (statement.StatementType)
                {
                    case StatementType.Height:
                        break;
                    case StatementType.HairColor:
                        break;
                    case StatementType.HatType:
                        break;
                    case StatementType.Sex:
                        if(Random.Range(0f,1f) < 0.4)
                            orderTargetChoseType = person.Data.Sex == Sex.Female
                                ? orderTargetChoseType = OrderTargetChoseType.AlwaysOrderFemale
                                : orderTargetChoseType = OrderTargetChoseType.AlwaysOrderMale;
                        return;
                    case StatementType.LowerColor:
                        break;
                    case StatementType.UpperColor:
                        break;
                    case StatementType.SkinColor:
                        if(Random.Range(0f,1f) < 0.6)
                            orderTargetChoseType = person.Data.SkinColor == SkinColor.Black
                                ? orderTargetChoseType = OrderTargetChoseType.OrdererIsRacist
                                : orderTargetChoseType = OrderTargetChoseType.Normal;
                        return;
                    case StatementType.Age:
                        if(Random.Range(0f,1f) < 0.6)
                            orderTargetChoseType = person.Data.Age == Age.Normal
                                ? orderTargetChoseType = OrderTargetChoseType.AlwaysOrderNoOld
                                : orderTargetChoseType = OrderTargetChoseType.Normal;
                        return;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        private void FillOrdererStatementChanges(IList<Statement> statements, Person person)
        {
            foreach (var statement in statements)
            {
                if (!statement.IsTrueForPerson(person) && Random.Range(0f,1f) <= 1f)
                {
                    ordererStatementChanges.Type = statement.StatementType;
                    ordererStatementChanges.XValue = person.GetStatementValue(statement.StatementType);
                    ordererStatementChanges.YValue = statement.Value;
                    return;
                }
            }
        }

        private void FillOrdererIntStruct(IList<Statement> statements, Person person)
        {
            var counter = statements.Sum(statement => statement.IsTrueForPerson(person) ? 1 : 0);

            switch (counter)
            {
                case 0 :
                    ordererIntStruct.OrderStatementType = OrderStatementType.AlwaysSaysFalse;
                    break;
                case 1 :
                    var random = Random.Range(0f, 1f);
                    if (random <= 0.5f)
                    {
                        ordererIntStruct.OrderStatementType = OrderStatementType.NumberXStatementIsTrue;
                        ordererIntStruct.X = statements.IndexOf(statements.First(x => x.IsTrueForPerson(person)));
                    }
                    else
                    {
                        ordererIntStruct.OrderStatementType = OrderStatementType.Xof3StatementsIsCorrect;
                        ordererIntStruct.X = 1;
                    }

                    break;
                case 2 :
                    var random2 = Random.Range(0f, 1f);
                    if (random2 <= 0.5f)
                    {
                        ordererIntStruct.OrderStatementType = OrderStatementType.NumberXStatementIsFalse;
                        ordererIntStruct.X = statements.IndexOf(statements.First(x => !x.IsTrueForPerson(person)));
                    }
                    else
                    {
                        ordererIntStruct.OrderStatementType = OrderStatementType.Xof3StatementsIsCorrect;
                        ordererIntStruct.X = 2;
                    }
                    break;
                case 3 :
                    ordererIntStruct.OrderStatementType = OrderStatementType.AlwaysSaysTrue;
                    break;
            }
        }

    }
}