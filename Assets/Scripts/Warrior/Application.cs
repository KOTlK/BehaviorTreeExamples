using UnityEngine;

namespace Examples.Warrior
{
    public class Application : MonoBehaviour
    {
        [SerializeField] private AggressiveCharacter _aggressiveCharacter;
        [SerializeField] private TreeVisualization _debug;

        private void FixedUpdate()
        {
            var time = (long) (Time.realtimeSinceStartupAsDouble * 1000);
            _aggressiveCharacter.Execute(time);
            _aggressiveCharacter.VisualizeTree(_debug);
            _debug.Visualize();
        }
    }
}