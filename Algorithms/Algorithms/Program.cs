namespace Path.Console
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using static Path.Console.LinkedList;

    public static class Program
    {
        public static void Main(string[] args)
        {
            HashTable hashTable = new HashTable(0xFFFFFFFF);
            hashTable.CrcTable(0xFFFFFFFF);

            hashTable.AddToList("test");

            hashTable.DeleteToList("test");

            hashTable.SearchLinkedList("test");


        }

    }
}

