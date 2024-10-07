using Character.Common;

namespace Character.Player
{
    public class PlayerAnimationController : AnimationController
    {
        // Animationtrigger
        private const string _jump = "Jump";
        private const string _speed = "Speed";

        // Trigger
        
        public void SetSpeedTrigger(float speed)
        {
            SetAnimatorFloat(_speed, speed);
        }

        public void SetJumpTrigger()
        {
            SetTrigger(_jump);
        }

        // AnimationState
        private const string _jumpState = "Jump";
        
        // StateJudge
        public bool IsJumpState()
        {
            return IsCurrentAnimationState(_jumpState);
        }

        // AnimationEventFlg
        private bool _isJumpStart;
        private bool _isJumpTop;
        public bool IsJumpStart => _isJumpStart;
        public bool IsJumpTop => _isJumpTop;
        
        // AnimationEvent
        public void SetIsJumpStart()
        {
            _isJumpStart = true;
        }

        public void SetIsJumpTop()
        {
            _isJumpTop = true;
            Pause();
        }

        public void ResetIsJumpFlg()
        {
            _isJumpStart = false;
            _isJumpTop = false;
        }
    }
}
