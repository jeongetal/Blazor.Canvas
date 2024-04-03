using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.Canvas.Model.Models
{
    internal class Model
    {
        public string Sequence { get; set; } = string.Empty;
        public string Data { get; set; } = string.Empty;
        public bool IsDeleted { get; set; } = false;
        public DateTime CreatedTime { get; set; } = new();
        public DateTime ModifiedTime { get; set; } = new();
    }
}
