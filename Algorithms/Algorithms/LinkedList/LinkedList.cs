namespace Path.Console
{

    public class LinkedList
    {
        public Node head;
        // Linked List

        // 🔥 HW arraysiz ve listesiz linked list. Single Linked List
        public class Node
        {
            public Node next;
            public string data;
            public Node(string d)
            {
                data = d;
                next = null;
            }
        }

        public LinkedList()
        {
            head = new Node(null);
        }

        // Add -> prepand
        public void AddPrepand(string new_data)
        {
            Node new_node = new Node(new_data);
            new_node.next = head;
            head = new_node;
        }
        // Add -> append
        public void AddAppend(string new_data)
        {
            var new_node = new Node(new_data);
            if (head == null)
            {
                head = new_node;
                return;
            }
            var lastNode = RetrieveLastNode();
            lastNode.next = new_node;
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
        // Add -> random
        public void AddRandom(Node prev_node, string new_data)
        {
            Node new_node = new Node(new_data);
            new_node.next = prev_node.next;
            prev_node.next = new_node;
        }

        // Delete -> random
        public void DeleteRandomNode(string value)
        {
            Node currentNode = head;
            Node prev = null;
            if (currentNode != null && currentNode.data == value)
            {
                head = currentNode.next;
                return;
            }
            while (currentNode != null && currentNode.data != value)
            {
                prev = currentNode;
                currentNode = currentNode.next;
            }
            prev.next = currentNode.next;
        }
        // Delete -> tail
        public void deleteTailNode()
        {
            Node currentNode = head;
            Node prev = null;
            while (currentNode.next != null)
            {
                prev = currentNode;
                currentNode = currentNode.next;
            }
            if (prev == null)
            {
                 head = null;
            }
            else
            {
                prev.next = null;
            }
        }
        // Search & Find
        public bool searchLinkedList(string key)
        {
            Node currentNode = head;

            while (currentNode != null)
            {
                if (currentNode.data == key)
                {
                    return true;
                }
                currentNode = currentNode.next;
            }
            return false;
        }
        // Ref: https://www.geeksforgeeks.org/linked-list-implementation-in-c-sharp/
    }
}

