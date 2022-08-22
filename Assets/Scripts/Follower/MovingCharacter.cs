using UnityEngine;

namespace Examples.Follower
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class MovingCharacter : MonoBehaviour, IMovingCharacter
    {
        [SerializeField] private float _speed = 5f;

        private Rigidbody2D _rigidbody;
        
        public Vector2 Position => transform.position;

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        public void Move(Vector2 direction)
        {
            var deltaMovement = direction.normalized * _speed * Time.deltaTime;
            
            _rigidbody.MovePosition(_rigidbody.position + deltaMovement);
        }
    }
}