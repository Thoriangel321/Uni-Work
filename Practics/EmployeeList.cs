using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.IO;

namespace Practics
{
    internal class EmployeeList
    {
        private Node head;
        private Node tail;
        private Node iteratorNode;

        public int Length { get; private set; }

        public void AddLast(Employee emp)
        {
            Node newNode = new Node(emp);
            if (head == null) head = tail = newNode;
            else
            {
                tail.Next = newNode;
                newNode.Prev = tail;
                tail = newNode;
            }
            Length++;
        }

        public void RemoveFirst()
        {
            if (head == null) throw new InvalidOperationException("List is empty.");
            head = head.Next;
            if (head != null) head.Prev = null;
            else tail = null;
            Length--;
        }

        public Employee this[int index]
        {
            get => GetNodeAt(index).Data;
            set => GetNodeAt(index).Data = value;
        }

        private Node GetNodeAt(int index)
        {
            if (index < 0 || index >= Length)
                throw new IndexOutOfRangeException("Invalid index.");
            Node temp = head;
            for (int i = 0; i < index; i++) temp = temp.Next;
            return temp;
        }

        public Employee GetFirst()
        {
            if (head == null) throw new InvalidOperationException("List is empty.");
            iteratorNode = head;
            return iteratorNode.Data;
        }

        public Employee GetNext()
        {
            if (iteratorNode == null || iteratorNode.Next == null) return null;
            iteratorNode = iteratorNode.Next;
            return iteratorNode.Data;
        }

        public double GetAverageSalary()
        {
            if (Length == 0) return 0;
            double sum = 0;
            Node temp = head;
            while (temp != null)
            {
                sum += temp.Data.Salary;
                temp = temp.Next;
            }
            return sum / Length;
        }

        public EmployeeList Search()
        {
            EmployeeList result = new EmployeeList();
            double avg = GetAverageSalary();
            Node temp = head;
            while (temp != null)
            {
                if (temp.Data.Salary < avg && temp.Data.IsRemote)
                    result.AddLast(temp.Data);
                temp = temp.Next;
            }
            return result;
        }
    }
}