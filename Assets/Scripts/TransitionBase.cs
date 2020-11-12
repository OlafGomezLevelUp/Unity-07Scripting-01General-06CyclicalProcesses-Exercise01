using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TransitionBase<T> : MonoBehaviour
{
    public int Loops { get; private set; }

    [SerializeField]
    private List<T> _values;

    [SerializeField]
    private float _transition = 2f;

    private T _currentValue;

    private int _valueIndex;

    protected virtual void Start()
    {
        _valueIndex = 0;

        Loops = 0;

        StartCoroutine(DoTransition());
    }

    protected IEnumerator DoTransition()
    {
       float transitionStep = 0;

       while (_transition > transitionStep)
       {
            transitionStep += Time.deltaTime;

          float step = transitionStep / _transition;
                
          Tweening(_currentValue, _values[_valueIndex], step);

          yield return null;
       }

       _currentValue = _values[_valueIndex];

       _valueIndex = (_valueIndex + 1) % _values.Count;

       Loops++;

       StartCoroutine(DoTransition());
    }

    protected abstract void Tweening(T current, T next, float step);

    protected void SetCurrentValue(T current)
    {
        _currentValue = current;
    }
}
