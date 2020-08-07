using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace FirstProject.Models
{
    public class BossViewModel
    { 
        public int Id { get; set; }

        [Display(Name="Название босса")]
        public string Name { get; set; }

        [Display(Name="Время респа в часах без 5 минут!!")]
        public int KdTime { get; set; }

        
        public int KdCount { get; set; }

        

        public DateTime? LastTime { get; set; }

        //public DateTime LastDateTime { get; set; }
    }

    
}