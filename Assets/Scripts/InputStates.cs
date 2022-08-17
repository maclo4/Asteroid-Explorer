using UnityEngine;

namespace Scripts
{
    public class InputStates
    {
        public InputStatesEnum left, right, up, down, boost, shoot;
        public Vector2 aim;
        public Vector2 defaultAim;

        public InputStates()
        {
            left = InputStatesEnum.Raised;
            right = InputStatesEnum.Raised;
            up = InputStatesEnum.Raised;
            down = InputStatesEnum.Raised;
            boost = InputStatesEnum.Raised;
            shoot = InputStatesEnum.Raised;
            aim = Vector2.zero;
            defaultAim = Vector2.right;
        }
    }
}