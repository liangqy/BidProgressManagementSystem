using System;
using System.Collections.Generic;
using System.Text;

namespace BidProgressManagementSystem.EntityFramework
{
    public class TreeModel
    {
        public string Id { get; set; }

        public string Text { get; set; }

        public string Parent { get; set; }
    }
}
