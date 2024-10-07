using System.Collections;
using System.Collections.Generic;
using Character.Common;
using UnityEngine;

namespace Character.NPC
{
    public class NpcAnimationController : AnimationController
    {
        // Animetion Trigger
        private const string _speed = "Speed";

        public void SetSpeedTrigger(float value)
        {
            SetAnimatorFloat(_speed, value);
        }
    }
}
