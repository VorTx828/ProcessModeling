using System.ComponentModel.DataAnnotations;

namespace Model.Data
{
    public class Variants
    {
        [Key]
        public int Id { get; set; }

        public int? UserId {  get; set; }
        public double Height { get; set; }
        public double T_material { get; set; }

        public double T_gas { get; set; }
        public double C_material {  get; set; }
        public double C_gas { get; set; }
        public double G { get; set; }

        public double d { get; set; }
        public double W { get; set; }
        public double av { get; set; }

        public double step { get; set; }


    }
}
