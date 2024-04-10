using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.Canvas.Model.Models
{
    public class Note
    {
        public int Id { get; set; } = 0;
        public string Title { get; set; } = string.Empty;
        public string Data { get; set; } = string.Empty;
        public string CreatedBy { get; set; } = string.Empty;
        public string ModifiedBy { get; set; } = string.Empty;
    }
}
