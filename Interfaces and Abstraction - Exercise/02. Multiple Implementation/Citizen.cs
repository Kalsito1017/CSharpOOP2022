﻿using System;
using System.Collections.Generic;
using System.Text;

namespace PersonInfo
{
    public class Citizen : IBirthable, IIdentifiable, IPerson
    {
        public string Name { get; }
        public int Age { get; }
        public string Id { get; }
        public string Birthdate { get; }

        public Citizen(string name, int age, string id, string birthdate)
        {
            Name = name;
            Age = age;
            Id = id;
            Birthdate = birthdate;
        }
    }
}
