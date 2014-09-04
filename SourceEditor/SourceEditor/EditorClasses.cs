using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace SourceEditor
{
    public class EditorClasses
    {
        [DisplayName("Site Name"),
        DescriptionAttribute("The name of the site."),
        CategoryAttribute("Site Configuration")]
        public string Name { get; set; }


        [DisplayName("Friend Code"),
        DescriptionAttribute("Your 3DS Friend Code. This does not actually have to be a friend code, it's shown in the top left corner of the site. HTML can be used."),
        CategoryAttribute("Site Information Configuration")]
        public string LeftLabel { get; set; }

        [DisplayName("Point of Contact"),
        DescriptionAttribute("Your point of contact. This does not actually have to be a contact link, it's shown in the top right corner of the site. HTML can be used."),
        CategoryAttribute("Site Information Configuration")]
        public string RightLabel { get; set; }


        [DisplayName("Site Pokémon Links"),
        DescriptionAttribute("The number of Pokémon displayed at one point in time before loading the next series."),
        CategoryAttribute("Site Configuration")]
        public int PaginationCount { get; set; }

        [DisplayName("Pokémon"),
        DescriptionAttribute("Your available Pokémon. Keep this regularly updated."),
        CategoryAttribute("Site Pokemon Configuration")]
        public List<EditorClassesPokemon> Pokemon { get; set; }

        public EditorClasses()
        {
            Pokemon = new List<EditorClassesPokemon>();
        }
    }

    public class EditorClassesPokemon
    {
        public string Species { get; set; }
        public string Gender { get; set; }
        public bool Shiny { get; set; }
        public string Nature { get; set; }
        public string Ability { get; set; }
        public string OT { get; set; }
        public int OTID { get; set; }
        public string HP { get; set; }
        public string Atk { get; set; }
        public string Def { get; set; }
        public string SpA { get; set; }
        public string SpD { get; set; }
        public string Spe { get; set; }
        public string Move1 { get; set; }
        public string Move2 { get; set; }
        public string Move3 { get; set; }
        public string Move4 { get; set; }
    }
}
