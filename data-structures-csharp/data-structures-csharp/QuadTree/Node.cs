﻿using System;
using System.Diagnostics.Contracts;


namespace DataStructures.QuadTreeSpace
{
    /// <summary>
    /// Node of Heap
    /// </summary>
    /// <typeparam name="T">Data type</typeparam>
    [Serializable]
    public class Node<T>
        where T : IComparable<T>, IEquatable<T>
    {
        private T val;
        private readonly Rectangle region;

        public T Value
        {
            get { return val; }
            internal set
            {
                Contract.Requires<ArgumentNullException>(value != null);
                val = value;
            }
        }
        internal Node<T> Parent { get; set; }
        internal Rectangle Region
        {
            get { return region; }
        }
        internal Children<T> Children { get; set; }

        public Node(Rectangle rectangle, T val, Node<T> parent)
        {
            this.val = val;
            Parent = parent;
            region = rectangle;
            Children = new NullChildren<T>();
        }

        public bool IsInRegion(Point p)
        {
            return region.IsInRectangle(p);
        }



        public bool Equals(Node<T> otherNode)
        {
            if (otherNode == null)
            {
                return false;
            }
            return val.Equals(otherNode.Value);
        }

        public override bool Equals(object obj)
        {
            Node<T> otherNode = obj as Node<T>;
            if (otherNode == null)
            {
                return false;
            }
            return val.Equals(otherNode.Value);
        }

        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hash = 17;
                // Suitable nullity checks etc, of course :)
                hash = hash * 23 + val.GetHashCode();
                return hash;
            }
        }
    }
}
