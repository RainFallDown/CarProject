using System.ComponentModel.DataAnnotations;

namespace CarProject.Core.Model;

    public enum SortField
    {
        [Display(Name = "price")]
        Price,

        [Display(Name = "year")]
        Year,

        [Display(Name = "km")]
        Km
    }
    public enum SortDirection
    {
        [Display(Name = "ASC")]
        ASC,

        [Display(Name = "DESC")]
        DESC
    }
    public enum Gear
    {
        [Display(Name = "Düz")]
        Duz,

        [Display(Name = "Otomatik")]
        Otomatik,

        [Display(Name = "Yarı Otomatik")]
        YariOtomatik
    }
    public enum Fuel
    {
        [Display(Name = "Benzin")]
        Benzin,

        [Display(Name = "Dizel")]
        Dizel,

        [Display(Name = "LPG & Benzin")]
        LpgBenzin
    }
