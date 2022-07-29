using UnityEngine;

namespace Scripts
{
    public class InputStates
    {
        public InputStatesEnum left, right, up, down, jump, shoot;
        public Vector2 aim = Vector2.right;

        public InputStates()
        {
            left = InputStatesEnum.Raised;
            right = InputStatesEnum.Raised;
            up = InputStatesEnum.Raised;
            down = InputStatesEnum.Raised;
            jump = InputStatesEnum.Raised;
            shoot = InputStatesEnum.Raised;
            aim = Vector2.zero;
        }
    }
}