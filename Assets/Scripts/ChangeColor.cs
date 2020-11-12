using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : TransitionBase<Color>
{
   
    private Renderer _myRenderer;

    private void Awake()
    {
        _myRenderer = GetComponent<Renderer>();
    }

    protected override void Start()
    {
        SetCurrentValue(_myRenderer.material.color);
        base.Start();
    }

    protected override void Tweening(Color current, Color next, float step)
    {
        _myRenderer.material.color = Color.Lerp(current, next, step);
    }


}
