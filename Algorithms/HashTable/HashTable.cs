namespace Path.Console
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class HashTable
    {
        private readonly uint[] crc32_tab;
        private readonly uint crcCode;

        public List<Node> values;

        public Node head;


        public HashTable(UInt32 crcCode)
        {
            this.crcCode = crcCode;
            crc32_tab = CrcTable(crcCode);

            this.values = new List<Node>();

        }

        public class Node
        {
            public Node head;
            public Node next;
            public string value;
            public uint key;

            public Node(uint key, string value)
            {
                this.head = null;
                this.next = null;
                this.value = value;
                this.key = key;
            }
        }

        public uint[] CrcTable(UInt32 crcCode)
        {
            uint[] crc32Table = new uint[256];
            uint newByte = 0;

            for (uint i = 0; i < 256; i++)
            {
                newByte = i;
                for (int j = 0; j < 8; j++)
                {
                    if ((newByte & 1) == 1)
                    {
                        newByte = (newByte >> 1) ^ crcCode;
                    }
                    else
                    {
                        newByte >>= 1;
                    }
                }
                crc32Table[i] = newByte;
            }
            foreach (uint a in crc32Table)
            {
                Console.WriteLine("{0:X4}", a);

            }
            return crc32Table;
        }

        public uint Hash(string data)
        {
            byte[] byteArray = Encoding.ASCII.GetBytes(data);

            uint hash = 0xFFFFFFFF;
            for (int i = 0; i < byteArray.Length; ++i)
            {
               hash = crc32_tab[(hash ^ byteArray[i]) & 0xFF] ^ (hash >> 8);
            }
            return ~hash;
        }

        public void AddToList(string value)
        {
            uint hashCode = Hash(value);

            var index = FindIndexOfLinkedList(hashCode);

            if (index != -1)
            {
                Node node = values[index];

                var new_node = new Node(hashCode, value);

                if (node.head == null)
                {
                    node.head = new_node;
                    return;
                }
                var lastNode = RetrieveLastNode();
                lastNode.next = new_node;

            }
            else
            {
                var new_node = new Node(hashCode, value);

                head = new_node;

                values.Add(new_node);
            }
        }

        public Node RetrieveLastNode()
        {
            Node new_head = head;
            while (new_head.next != null)
            {
                new_head = new_head.next;
            }
            return new_head;
        }

        public int FindIndexOfLinkedList(uint key)
        {
            int index = -1;
            if (values != null)
            {
                for (int i = 0; i < values.Count; i++)
                {
                    if (key == values[i].key)
                    {
                        index = i;
                    }
                }
            }
            return index;
        }

        public bool DeleteToList(string value)
        {
            uint hashCode = Hash(value);
            var index = FindIndexOfLinkedList(hashCode);
            if (index != -1)
            {
                Node currentNode = values[index];
                Node prev = null;
                if (currentNode != null && currentNode.value == value)
                {
                    head = currentNode.next;
                    return true;
                }
                while (currentNode != null && currentNode.value != value)
                {
                    prev = currentNode;
                    currentNode = currentNode.next;
                }
                prev.next = currentNode.next; 
            }
            return false;
        }

        public bool SearchLinkedList(string value)
        {
            uint hashCode = Hash(value);
            var index = FindIndexOfLinkedList(hashCode);

            Node currentNode = head;
            while (currentNode != null)
            {
                if (currentNode.value == value)
                {
                    return true;
                }
                currentNode = currentNode.next;
            }
            return false;
        }
    }
}