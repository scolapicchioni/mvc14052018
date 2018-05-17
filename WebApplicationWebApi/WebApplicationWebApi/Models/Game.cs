using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationWebApi.Models
{
    public class Game
    {
        public int Id { get; set; }
        public int PlayerId { get; set; }
        public string Name { get; set; }
    }
}