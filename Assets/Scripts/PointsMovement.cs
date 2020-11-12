using System.Collections.Generic;
using UnityEngine;

public class PointsMovement : TransitionBase<Vector3>
{

    protected override void Start()
    {
        SetCurrentValue(transform.position);
        base.Start();
        
    }

    protected override void Tweening(Vector3 current, Vector3 next, float step)
    {
        transform.position = Vector3.Lerp(current, next, step);
    }
}
