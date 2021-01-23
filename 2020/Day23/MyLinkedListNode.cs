using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day23
{
    /// <summary>
    /// The standard LinkedListNode library was giving me trouble..
    /// I wanted to easily destroy and link elements so I just made a bog-standard class here.
    /// </summary>
    public class MyLinkedListNode<T>
    {
        public MyLinkedListNode<T> Next { get; set; }

        public T Value { get; set; }

        public MyLinkedListNode(T value)
        {
            Value = value;
        }
    }
}
