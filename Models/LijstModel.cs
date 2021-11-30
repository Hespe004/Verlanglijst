using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace src.Models
{
    public class Lijst {
        [Key]
        public int Id { get; set; }
        public string Titel { get; set; }
        
        [DataType(DataType.Currency)]
        [Column(TypeName ="decimal(18, 2)")]
        public decimal Price { get; set;}

        [Display(Name = "Hoe graag ik het wil")]
        [Range(1,5)]
        public int Waarde { get; set; }
        public string Link { get; set; }

    }
    public class PS_Lijst : Lijst
    {
        public PS_Lijst() {}
        public PS_Lijst(string Gen, string Titel, decimal Price, int Waarde, string Link) {
            this.Gen = Gen;
            this.Titel = Titel;
            this.Price = Price;
            this.Waarde = Waarde;
            this.Link = Link;
        }
        public string Gen { get; set; }  
    }

    public class BR_Lijst : Lijst
    {
        public BR_Lijst() {}
        public BR_Lijst(string Type, string Titel, decimal Price, int Waarde, string Link) {
            this.Type = Type;
            this.Titel = Titel;
            this.Price = Price;
            this.Waarde = Waarde;
            this.Link = Link;
        }
        public string Type { get; set; }  
    }

    public class Verzamel_Lijst : Lijst
    {
        public Verzamel_Lijst() {}
        public Verzamel_Lijst(string Type, string Titel, decimal Price, int Waarde, string Link) {
            this.Type = Type;
            this.Titel = Titel;
            this.Price = Price;
            this.Waarde = Waarde;
            this.Link = Link;
        }
        public string Type { get; set; }
    }

    public class Overig_Lijst : Lijst
    {
        public Overig_Lijst() {}
        public Overig_Lijst(string Type, string Titel, decimal Price, int Waarde, string Link) {
            this.Type = Type;
            this.Titel = Titel;
            this.Price = Price;
            this.Waarde = Waarde;
            this.Link = Link;
        }
        public string Type { get; set; }
    }
}