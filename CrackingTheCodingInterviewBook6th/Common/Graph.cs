using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Common
{

    public enum VertexState { Undiscovered, Discovered, Processed };

    public class Graph
    {
        private HashSet<int>[] _adjList;

        public Graph(int v, IList<(int from, int to)> edges, bool isDirected)       
        {
            if (v < 1) throw new ArgumentOutOfRangeException("v");

            V = v;
            IsDirected = isDirected;

            _adjList = new HashSet<int>[V+1];
            for(var i = 1; i <= V; i++)
            {
                _adjList[i] = new HashSet<int>(V);
            }

            foreach(var e in edges)
            {
                AddEdge(e.from, e.to, IsDirected);
            }

            for(var i = 1; i <= V; i++)
            {
                _adjList[i].TrimExcess();
            }
        }

        private void AddEdge(int from, int to, bool isDirected)
        {
            ValidateVertexIndexOrThrow(from);
            ValidateVertexIndexOrThrow(to);

            _adjList[from].Add(to);
            E++;
            if (!isDirected)
            {
                _adjList[to].Add(from);
                E++;
            }
        } 

        private void ValidateVertexIndexOrThrow(int vertexIndex) 
        {
            if (vertexIndex < 1 || vertexIndex > V)
            {
                throw new ArgumentOutOfRangeException($"{vertexIndex} is not in the range 1 to {V}");
            }
        }

        public int V { get; private set; }

        public int E { get; private set; }

        public IReadOnlyCollection<int> Edges(int vertexIndex)
        {
            ValidateVertexIndexOrThrow(vertexIndex);
            return _adjList[vertexIndex];
        }         

        public bool IsDirected { get; private set; }       
    }
}