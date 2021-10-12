using System;
using System.Collections.Generic;
using System.Linq;
using Common;

namespace Misc
{
   /**
    * Topological Sort implementation on DAG based
    * on Algorithm Design Manual, 2ed. pg.178-180.
    * O(V+E) - Time complexitiy, O(V) - Space complexitiy.
    */
    public class TopologicalSort : DepthFirstSearch
    {
        private Stack<int> _sorted;
        private bool _hasCycle;
        private IList<int> _cycle;

        public void Sort(Graph g)
        {
            if (g == null) throw new ArgumentNullException(nameof(g));

            _state = new VertexState[g.V+1];
            _parent = new int[g.V+1];
            _entryTime = new int[g.V+1];
            _exitTime = new int[g.V+1];
            _sorted = new Stack<int>(g.V);

            for(var i = 1; i <= g.V; i++)
            {
                if (_state[i] == VertexState.Undiscovered)
                {
                    Dfs(g, i);
                }
            }
        }

        protected override void ProcessVertexLate(int x)
        {
            _sorted.Push(x);
        }

        protected override void ProcessEdge(int x, int y)
        {
            var edgeType = EdgeClassification(x,y);

            if (edgeType == EdgeType.Back)
            {
                _hasCycle = true;
                _cycle = FindPath(y,x);
            }
        }

        private EdgeType EdgeClassification(int x, int y)
        {
            if (_parent[y] == x) return EdgeType.Tree;

            if (_state[y] == VertexState.Discovered) return EdgeType.Back;

            if (_state[y] == VertexState.Processed && _entryTime[y] > _entryTime[x]) return EdgeType.Forward;

            if (_state[y] == VertexState.Processed && _entryTime[y] < _entryTime[x]) return EdgeType.Cross;

            throw new InvalidOperationException($"Processing edge {x}->{y} encountered an invalid processing state.");
        }

        public (bool hasCycle, IList<int> pathOrCycle) Results
        {
            get
            {
                if (_sorted == null) throw new InvalidOperationException($"First call Sort(..) on this instance.");

                return (_hasCycle, _hasCycle ? _cycle : _sorted.ToList());
            }
        }
    }
}