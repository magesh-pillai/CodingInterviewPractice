using System;
using Common;

namespace Chapter4
{
    enum Status { Undiscovered, Discovered, Processed }

    public class RouteChecker
    {
       /**
        * Determines if directed graph g has a path from
        * vertex s to t. O(V+E) time complexity. O(V) stack space.
        */
        public static bool HasRoute(Graph g, int s, int t)
        {
            ValidateVertex(g, s, nameof(s));
            ValidateVertex(g, t, nameof(t));

            if (s == t) return true;

            var vertexStatuses = new Status[g.V+1];
            return HasRoute(g, s, t, vertexStatuses);
        }

        private static bool HasRoute(Graph g, int s, int t, Status[] vertexStatuses)
        {
            vertexStatuses[s] = Status.Discovered;

            foreach(var to in g.Edges(s))
            {
                if (to == t) return true;

                if (vertexStatuses[to] == Status.Undiscovered && HasRoute(g, to, t, vertexStatuses))
                {
                    return true;
                }
            }

            vertexStatuses[s] = Status.Processed;
            return false;
        }

        private static void ValidateVertex(Graph g, int vertex, string errorMsg) 
        {
            if (vertex < 1 || vertex > g.V)
            {
                throw new ArgumentOutOfRangeException($"{errorMsg}");
            }
        }
    }
}