
namespace HalaqatManagmentSystem_API.Enums
{
    // RelationshipToGuardian
    public enum GuardianKinship
    {
        [Display(Name = "أب")]
        Father,

        [Display(Name = "أم")]
        Mother,

        [Display(Name = "عم")]
        Uncle,

        [Display(Name = "خال")]
        MaternalUncle,

        [Display(Name = "أخ")]
        Brother,

        [Display(Name = "أخت")]
        Sister,

        [Display(Name = "جد")]
        Grandfather,

        [Display(Name = "جدة")]
        Grandmother,

        [Display(Name = "ابن عم")]
        CousinPaternal, // Male cousin from paternal side

        [Display(Name = "ابنة عم")]
        CousinMaternal, // Female cousin from maternal side

        [Display(Name = "زوج")]
        Husband,

        [Display(Name = "زوجة")]
        Wife,

    }

}
