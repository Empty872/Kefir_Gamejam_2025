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
            
        }

        private void FillOrdererIntStruct(IList<Statement> statements, Person person)
        {
            
        }






























        // private void ApplyStatementChange(OrdererStatementChangesClass ordererStatementChanges, IEnumerable<Statement> statements)
        // {
        //     foreach (var statement in statements)
        //     {
        //         if (statement.CanApplyChangingType(ordererStatementChanges.Type, ordererStatementChanges.XValue))
        //         {
        //             statement.ApplyChangingType(ordererStatementChanges.Type, ordererStatementChanges.XValue, ordererStatementChanges.YValue)
        //         }
        //     }
        // }
        //
        // private OrdererIntStruct ApplyStatementLogicAndReturnOrderIntStruct(OrdererIntStruct ordererIntStruct, IEnumerable<Statement> statements, Person person)
        // {
        //     switch (ordererIntStruct.OrderStatementType)
        //     {
        //         case OrderStatementType.AlwaysSaysTrue:
        //             return AlwaysSaysTrue(ordererIntStruct, statements, person);
        //         case OrderStatementType.AlwaysSaysFalse:
        //             return AlwaysSaysFalse(ordererIntStruct, statements, person);
        //         case OrderStatementType.XStatementIsFalse:
        //             return XStatementIsFalse(ordererIntStruct, statements.ToList(), person);
        //         case OrderStatementType.XStatementIsTrue:
        //             return XStatementIsTrue(ordererIntStruct, statements.ToList(), person);
        //         case OrderStatementType.Xof3StatementsIsCorrect:
        //             return Xof3StatementsIsCorrect(ordererIntStruct, statements, person);
        //         default:
        //             throw new ArgumentOutOfRangeException();
        //     }
        // }

        // private OrdererIntStruct AlwaysSaysTrue(OrdererIntStruct ordererIntStruct, IEnumerable<Statement> statements, Person person)
        // {
        //     if (statements.All(st => st.IsTrueForPerson(person)))
        //         return ordererIntStruct;
        //     ordererIntStruct.OrderStatementType = OrderStatementType.None;
        //     return ordererIntStruct;
        // }
        //
        // private OrdererIntStruct AlwaysSaysFalse(OrdererIntStruct ordererIntStruct, IEnumerable<Statement> statements, Person person)
        // {
        //     foreach (var statement in statements)
        //     {
        //         if (statement.IsTrueForPerson(person))
        //         {
        //             statement.SetFalse(person);
        //         }
        //     }
        //
        //     return ordererIntStruct;
        // }
        //
        // private OrdererIntStruct XStatementIsFalse(OrdererIntStruct ordererIntStruct, List<Statement> statements, Person person)
        // {
        //     for (int i = 0; i < statements.Count; i++)
        //     {
        //         var st = statements[i];
        //         if (st.IsTrueForPerson(person)) continue;
        //         ordererIntStruct.X = i;
        //         return ordererIntStruct;
        //     }
        //     statements[ordererIntStruct.X].SetFalse(person);
        //     return ordererIntStruct;
        // }
        //
        // private OrdererIntStruct XStatementIsTrue(OrdererIntStruct ordererIntStruct, List<Statement> statements, Person person)
        // {
        //     for (int i = 0; i < statements.Count; i++)
        //     {
        //         var st = statements[i];
        //         if (st.IsTrueForPerson(person))
        //         {
        //             ordererIntStruct.X = i;
        //             return ordererIntStruct;
        //         }
        //     }
        //     ordererIntStruct.OrderStatementType = OrderStatementType.None;
        //     return ordererIntStruct;
        // }
        //
        // private OrdererIntStruct Xof3StatementsIsCorrect(OrdererIntStruct ordererIntStruct, IEnumerable<Statement> statements, Person person)
        // {
        //     return null;
        // }
        
    }
}