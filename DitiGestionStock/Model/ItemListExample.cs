﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DitiGestionStock.Model
{
    public class ItemListExample
    {
        public string Text { get; set; }
        public int? Value { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }

}
