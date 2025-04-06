using System.Collections;
using System.Collections.Generic;
using Charcter;
using Orderer;
using UnityEngine;

public class Person : MonoBehaviour
{
    [SerializeField] private PersonData personData;
    public PersonData Data => personData;

    public int GetStatementValue(StatementType statementType)
    {
        return Data.GetStatementValue(statementType);
    }

    public int GetFalseStatementValue(StatementType statementType)
    {
        return Data.GetFalseStatementValue(statementType);
    }

    public int GetTrueFalseStatementValue(float probabilityTrue, StatementType statementType)
    {
        return Random.Range(0, 1f) < probabilityTrue
            ? GetStatementValue(statementType)
            : GetFalseStatementValue(statementType);
    }

    public void Die()
    {
        GameController.Instance.EndGame(GameController.Instance.Target == this);

        Destroy(gameObject);
    }
}