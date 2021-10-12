using System;
using System.Collections.Generic;
using Common;

namespace Misc
{
   /**
    * Breadth-First Search implementation based on 
    * The Algorithm Design Manual, 3rd Ed. Pg. (215).
    * O(V+E) - time complexity, O(V) - space complexity
    */
    public class BreadthFirstSearch
    {
        protected VertexState[] _state;
        protected int[] _parent;

        public void Search(Graph g, int start)
        {
            if (g == null) throw new ArgumentNullException(nameof(g));

            if (start < 1 || start > g.V) throw new ArgumentOutOfRangeException(nameof(start));

            _state = new VertexState[g.V+1];
            _parent = new int[g.V+1];

            var q = new Queue<int>(g.V);
            q.Enqueue(start);
            _state[start] = VertexState.Discovered;

            while (q.TryDequeue(out var s))
            {
                ProcessVertexEarly(s);
                _state[s] = VertexState.Processed;

                foreach (var t in g.Edges(s))
                {
                    if (_state[t] == VertexState.Undiscovered)
                    {
                        q.Enqueue(t);
                        _state[t] = VertexState.Discovered;
                        _parent[t] = s;
                    }

                    // This condition is for processing the specific edge.
                    // (a) The first case is for an undirected graph: an edge like v<->e 
                    // is processed only once in the direction of discovery.
                    // (b) The second case is for a directed graph: if we have explicit 
                    // edges like v->e and then e->v, this processes each edge once.
                    if (_state[t] != VertexState.Processed || g.IsDirected)
                    {
                        ProcessEdge(s,t);
                    }
                }

                ProcessVertexLate(s);       
            }
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

            if (_state[start] == VertexState.Undiscovered) throw new InvalidOperationException($"Run BFS first starting from {start} node.");

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