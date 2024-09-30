using Character.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : AnimationController
{
    // TODO AnimationController‚ÌŒ»İ‚Ìstate‚ğŒ©‚Â‚ÂƒgƒŠƒK[‚ğ“n‚·
    private const string _jump = "Jump";
    private const string _speed = "Speed";

    public void SetJumpTrigger(bool value)
    {
        SetAnimatorBool(_jump, value);
    }

    public void SetSpeedTrigger(float speed)
    {
        SetAnimatorFloat(_speed, speed);
    }
}
