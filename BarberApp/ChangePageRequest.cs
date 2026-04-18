using System;
using System.Collections.Generic;
using System.Text;

namespace BarberApp
{
    public class ChangePageRequest
    {
        public string Page { get; set; }
        public object? Query { get; set; }
    }
}