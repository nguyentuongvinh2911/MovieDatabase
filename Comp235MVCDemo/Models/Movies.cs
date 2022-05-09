using System.Collections.Generic;

namespace Comp235MVCDemo.Models
{
    public class Movies
    {
        public List<Movie> Items { get; set; }
        public int EditIndex { get; set; }
        public Movies() { }
    }
}