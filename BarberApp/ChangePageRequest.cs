using Azure.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace BarberApp
{
    public class ChangePageRequest
    {
        public string Page { get; set; } = null!;
        public object? Query { get; set; }
        public RequestAction Action { get; set; }
    }


    public enum RequestAction
    {
        Get, 
        Post,
        Delete,
        Patch
    }

}