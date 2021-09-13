using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Common
{
    public class Graph
    {
        private HashSet<int>[] _adjList;

        public Graph(int v, IList<(int from, int to)> edges, bool isDirected)       
        {
            if (v <= 0) throw new ArgumentOutOfRangeException("v");

            V = v;
            IsDirected = isDirected;

            _adjList = new HashSet<int>[V];
            for(var i = 0; i < V; i++)
            {
                _adjList[i] = new HashSet<int>(V);
            }

            foreach(var e in edges)
            {
                AddEdge(e.from, e.to, IsDirected);
            }

            for(var i = 0; i < V; i++)
            {
                _adjList[i].TrimExcess();
            }
        }

        private void AddEdge(int from, int to, bool isDirected)
        {
            ValidateVertexIndexOrThrow(from);
            ValidateVertexIndexOrThrow(to);

            _adjList[from].Add(to);
            if (!isDirected)
            {
                _adjList[to].Add(from);
            }
        } 

        private void ValidateVertexIndexOrThrow(int vertexIndex) 
        {
            if (vertexIndex < 0 || vertexIndex > V-1)
            {
                throw new ArgumentOutOfRangeException($"{vertexIndex} is not in the range 0 to {V-1}");
            }
        }

        public int V { get; private set; }

        public IReadOnlyCollection<int> E(int vertexIndex)
        {
            ValidateVertexIndexOrThrow(vertexIndex);
            return _adjList[vertexIndex];
        }         

        public bool IsDirected { get; private set; }       
    }
}