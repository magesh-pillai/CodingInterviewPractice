using System;
using System.Collections.Generic;
using Common;

namespace Misc
{
   /**
    * Depth-First Search implementation based
    * on The Algorith Design Manual, 2ed. pg. 171.
    * O(V+E) - Time complexity, O(V) - Space complexity.
    */
    public class DepthFirstSearch
    {
        protected VertexState[] _state;
        protected int[] _parent;
        protected int[] _entryTime;
        protected int[] _exitTime;
        private int _time;

        public void Search(Graph g, int start)
        {
            if (g == null) throw new ArgumentNullException(nameof(g));

            if (start < 1 || start > g.V) throw new ArgumentOutOfRangeException(nameof(start));

            _state = new VertexState[g.V+1];
            _parent = new int[g.V+1];
            _entryTime = new int[g.V+1];
            _exitTime = new int[g.V+1];
            _time = 0;

            Dfs(g, start);
        }

        protected void Dfs(Graph g, int s)
        {
            _state[s] = VertexState.Discovered;
            _time++;
            _entryTime[s] = _time;

            ProcessVertexEarly(s);
            foreach (var t in g.Edges(s))
            {
                if (_state[t] == VertexState.Undiscovered)
                {
                    _parent[t] = s;
                    ProcessEdge(s,t);
                    Dfs(g, t);
                }

                // This condition is for processing the specific edge.
                // (a) The first case is for an undirected graph: an edge like 
                //  a<->b should not be processed 'again' when the dfs starts 
                //  processing b. 
                // (b) The second case is for a directed graph: in that case the
                // edge like a->b and b->a have to be processed.
                if (
                    ((_state[t] != VertexState.Processed) && (_parent[s] != t))
                    || g.IsDirected                        
                    )
                {
                    ProcessEdge(s,t);
                }
            }

            ProcessVertexLate(s);

            _time++;
            _exitTime[s] = _time;
            _state[s] = VertexState.Processed;
        }

        protected virtual void ProcessVertexEarly(int x)
        {
        }

        protected virtual void ProcessEdge(int x, int y)
        {
        }

        protected virtual void ProcessVertexLate(int x)
        {
        }

        public IList<int> FindPath(int start, int end)
        {
            if (start < 1 || start > (_parent?.Length ?? 0)) throw new ArgumentOutOfRangeException(nameof(start));

            if (end < 1 || end > (_parent?.Length ?? 0)) throw new ArgumentOutOfRangeException(nameof(end));

            if (_state[start] == VertexState.Undiscovered) throw new InvalidOperationException($"Run DFS first start from {start} node.");

            var path = new List<int>(_parent.Length);
            FindPath(start, end, path);
            return path;
        }

        private void FindPath(int start, int end, IList<int> path)
        {
            if (start == end || end == 0)
            {
                path.Add(start);
            }
            else
            {
                FindPath(start, _parent[end], path);
                path.Add(end);
            }
        }
    }
}