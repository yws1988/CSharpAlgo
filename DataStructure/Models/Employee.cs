namespace CSharpAlgo.DataStructure.Model
{
    using System;

    public class Employee : IComparable<Employee>
    {
        public string Name { get; set; }
        public int Priority { get; set; }

        public Employee(string name, int priority)
        {
            Name = name;
            Priority = priority;
        }

        public int CompareTo(Employee obj)
        {
            return this.Priority - obj.Priority;
        }

        public override string ToString()
        {
            return this.Name + " : " + this.Priority;
        }
    }
}
