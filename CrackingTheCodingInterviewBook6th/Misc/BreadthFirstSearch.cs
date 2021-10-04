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
        private VertexState[] _discovered;
        private VertexState[] _processed;           
        private int[] _parent;

        public void Search(Graph g, int start)
        {
            if (g == null) throw new ArgumentNullException(nameof(g));

            if (start < 1 || start > g.V) throw new ArgumentOutOfRangeException(nameof(start));

            _discovered = new VertexState[g.V+1];
            _processed = new VertexState[g.V+1];
            _parent = new int[g.V+1];

            var q = new Queue<int>(g.V);
            q.Enqueue(start);
            _discovered[start] = VertexState.Discovered;

            while (q.TryDequeue(out var s))
            {
                ProcessVertexEarly(s);
                _processed[s] = VertexState.Processed;

                foreach (var t in g.Edges(s))
                {
                    if (_discovered[t] == VertexState.Undiscovered)
                    {
                        q.Enqueue(t);
                        _discovered[t] = VertexState.Discovered;
                        _parent[t] = s;
                    }

                    // This condition is for processing the specific edge.
                    // In a directed graph, if we have explicit edges like v->e and then e->v,
                    // this processes each edge once.
                    // In an undirected graph, the v->e is processed only once in the direction
                    // of discovery.
                    if (_processed[t] != VertexState.Processed || g.IsDirected)
                    {
                        ProcessEdge(s,t);
                    }
                }

                ProcessVertexLate(s);       
            }
        }

        protected virtual void ProcessVertexEarly(int vertex)
        {
        }

        protected virtual void ProcessEdge(int x, int y)
        {
        }

        protected virtual void ProcessVertexLate(int vertex)
        {
        }

        public IList<int> FindPath(int start, int end)
        {
            if (start < 1 || start > (_parent?.Length ?? 0)) throw new ArgumentOutOfRangeException(nameof(start));

            if (end < 1 || end > (_parent?.Length ?? 0)) throw new ArgumentOutOfRangeException(nameof(end));

            if (_processed[start] != VertexState.Processed) throw new InvalidOperationException($"Run BFS first starting from {start} node.");

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