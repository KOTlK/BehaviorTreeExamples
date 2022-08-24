using Examples;
using UnityEngine;

namespace Examples.Follower
{
    public class Application : MonoBehaviour
    {
        [SerializeField] private MovingCharacter _target;
        [SerializeField] private FollowingCharacter _follower;
        [SerializeField] private TreeVisualization _visualization;


        private void Awake()
        {
            _follower.Init(_target);
        }

        private void FixedUpdate()
        {
            var time = (long) (Time.realtimeSinceStartupAsDouble * 1000);
            _follower.Execute(time);
            _follower.VisualizeTree(_visualization);
            _visualization.Visualize();
        }
    }
}