using BananaParty.BehaviorTree;
using TMPro;
using UnityEngine;

namespace Examples
{
    public class TreeVisualization : MonoBehaviour, ITreeGraph<IReadOnlyBehaviorNode>
    {
        [SerializeField] private TMP_Text _text;

        private readonly DebugTreeGraph _graph = new DebugTreeGraph("Debug");

        public void Visualize()
        {
            _text.text = _graph.ToString();
            _graph.Clear();
        }

        public void StartChildGroup(int childCount) => _graph.StartChildGroup(childCount);

        public void Write(IReadOnlyBehaviorNode vertex) => _graph.Write(vertex);

        public void EndChildGroup() => _graph.EndChildGroup();

        public string Name => _graph.Name;
    }
}