using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyComponent1
{
    public class GswComponent1Base : ComponentBase
    {

        [Parameter]
        protected int Count { get; set; }
        [Parameter]
        protected string Message { get; set; }
    }
}

