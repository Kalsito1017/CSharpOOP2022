using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl.Models
{
    public class Robot : IIdentifiable
    {
        public string Id { get; }
        public string Model { get; }
        public Robot(string id, string model)
        {
            Id = id;
            Model = model;
        }
    }
}
