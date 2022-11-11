using System;
using System.Collections.Generic;
using System.Text;

namespace NSomeWorks
{
    enum Habitat
    {
        Water,
        Aviary,
        Aquarium
    }

    abstract class Animal
    {
        private string _name;

        private int _age;

        public Animal(string name, int age)
        {
            _name = name;
            _age = age;
        }

        public string Name
        {
            get { return _name; }
        }

        public int Age
        {
            get { return _age; }
        }

        public abstract void Move();
        public abstract Habitat GetHabitat();
    }
}
