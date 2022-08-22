using UnityEngine;

namespace Examples.Follower
{
    public interface IMovingCharacter
    {
        Vector2 Position { get; }
        void Move(Vector2 direction);
    }
}