using System;
using System.Collections;
using System.Collections.Generic;
using Charcter;
using Orderer;
using UnityEngine;
using Random = UnityEngine.Random;

public class Person : MonoBehaviour
{
    [SerializeField] private PersonData personData;
    private Animator animator;
    public PersonData Data => personData;

    public event Action Died; 

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

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
        GameController.Instance.SomeoneWasKilled(GameController.Instance.Target == this);
        animator.SetTrigger("Killed");
        StartCoroutine(DelayCoroutine(1f, () => Died?.Invoke()));
    }
    
    private IEnumerator DelayCoroutine(float waitInSeconds, Action action)
    {
        yield return new WaitForSeconds(waitInSeconds);
        action.Invoke();
    }
}