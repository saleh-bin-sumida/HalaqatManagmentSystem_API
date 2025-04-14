using HalaqatSchoolSystem.Shared.Attributes;

namespace HalaqatManagmentSystem_API.Enums;

public enum Surah
{
    [SurahInfo("الفاتحة", 7)]
    AlFatiha = 1,

    [SurahInfo("البقرة", 286)]
    AlBaqarah = 2,

    [SurahInfo("آل عمران", 200)]
    AalEImran = 3,

    [SurahInfo("النساء", 176)]
    AnNisa = 4,

    [SurahInfo("المائدة", 120)]
    AlMaidah = 5,

    [SurahInfo("الأنعام", 165)]
    AlAnam = 6,

    [SurahInfo("الأعراف", 206)]
    AlAraf = 7,

    [SurahInfo("الأنفال", 75)]
    AlAnfal = 8,

    [SurahInfo("التوبة", 129)]
    AtTawbah = 9,

    [SurahInfo("يونس", 109)]
    Yunus = 10,

    [SurahInfo("هود", 123)]
    Hud = 11,

    [SurahInfo("يوسف", 111)]
    Yusuf = 12,

    [SurahInfo("الرعد", 43)]
    ArRad = 13,

    [SurahInfo("إبراهيم", 52)]
    Ibrahim = 14,

    [SurahInfo("الحجر", 99)]
    AlHijr = 15,

    [SurahInfo("النحل", 128)]
    AnNahl = 16,

    [SurahInfo("الإسراء", 111)]
    AlIsra = 17,

    [SurahInfo("الكهف", 110)]
    AlKahf = 18,

    [SurahInfo("مريم", 98)]
    Maryam = 19,

    [SurahInfo("طه", 135)]
    Taha = 20,

    [SurahInfo("الأنبياء", 112)]
    AlAnbiya = 21,

    [SurahInfo("الحج", 78)]
    AlHajj = 22,

    [SurahInfo("المؤمنون", 118)]
    AlMuminun = 23,

    [SurahInfo("النور", 64)]
    AnNur = 24,

    [SurahInfo("الفرقان", 77)]
    AlFurqan = 25,

    [SurahInfo("الشعراء", 227)]
    AshShuara = 26,

    [SurahInfo("النمل", 93)]
    AnNaml = 27,

    [SurahInfo("القصص", 88)]
    AlQasas = 28,

    [SurahInfo("العنكبوت", 69)]
    AlAnkabut = 29,

    [SurahInfo("الروم", 60)]
    ArRum = 30,

    [SurahInfo("لقمان", 34)]
    Luqman = 31,

    [SurahInfo("السجدة", 30)]
    AsSajda = 32,

    [SurahInfo("الأحزاب", 73)]
    AlAhzab = 33,

    [SurahInfo("سبأ", 54)]
    Saba = 34,

    [SurahInfo("فاطر", 45)]
    Fatir = 35,

    [SurahInfo("يس", 83)]
    YaSin = 36,

    [SurahInfo("الصافات", 182)]
    AsSaffat = 37,

    [SurahInfo("ص", 88)]
    Sad = 38,

    [SurahInfo("الزمر", 75)]
    AzZumar = 39,

    [SurahInfo("غافر", 85)]
    Ghafir = 40,

    [SurahInfo("فصلت", 54)]
    Fussilat = 41,

    [SurahInfo("الشورى", 53)]
    AshShura = 42,

    [SurahInfo("الزخرف", 89)]
    AzZukhruf = 43,

    [SurahInfo("الدخان", 59)]
    AdDukhan = 44,

    [SurahInfo("الجاثية", 37)]
    AlJathiya = 45,

    [SurahInfo("الأحقاف", 35)]
    AlAhqaf = 46,

    [SurahInfo("محمد", 38)]
    Muhammad = 47,

    [SurahInfo("الفتح", 29)]
    AlFath = 48,

    [SurahInfo("الحجرات", 18)]
    AlHujurat = 49,

    [SurahInfo("ق", 45)]
    Qaf = 50,

    [SurahInfo("الذاريات", 60)]
    AdhDhariyat = 51,

    [SurahInfo("الطور", 49)]
    AtTur = 52,

    [SurahInfo("النجم", 62)]
    AnNajm = 53,

    [SurahInfo("القمر", 55)]
    AlQamar = 54,

    [SurahInfo("الرحمن", 78)]
    ArRahman = 55,

    [SurahInfo("الواقعة", 96)]
    AlWaqia = 56,

    [SurahInfo("الحديد", 29)]
    AlHadid = 57,

    [SurahInfo("المجادلة", 22)]
    AlMujadila = 58,

    [SurahInfo("الحشر", 24)]
    AlHashr = 59,

    [SurahInfo("الممتحنة", 13)]
    AlMumtahina = 60,

    [SurahInfo("الصف", 14)]
    AsSaff = 61,

    [SurahInfo("الجمعة", 11)]
    AlJumuah = 62,

    [SurahInfo("المنافقون", 11)]
    AlMunafiqun = 63,

    [SurahInfo("التغابن", 18)]
    AtTaghabun = 64,

    [SurahInfo("الطلاق", 12)]
    AtTalaq = 65,

    [SurahInfo("التحريم", 12)]
    AtTahrim = 66,

    [SurahInfo("الملك", 30)]
    AlMulk = 67,

    [SurahInfo("القلم", 52)]
    AlQalam = 68,

    [SurahInfo("الحاقة", 52)]
    AlHaqqa = 69,

    [SurahInfo("المعارج", 44)]
    AlMaarij = 70,

    [SurahInfo("نوح", 28)]
    Nuh = 71,

    [SurahInfo("الجن", 28)]
    AlJinn = 72,

    [SurahInfo("المزمل", 20)]
    AlMuzzammil = 73,

    [SurahInfo("المدثر", 56)]
    AlMuddathir = 74,

    [SurahInfo("القيامة", 40)]
    AlQiyama = 75,

    [SurahInfo("الإنسان", 31)]
    AlInsan = 76,

    [SurahInfo("المرسلات", 50)]
    AlMursalat = 77,

    [SurahInfo("النبأ", 40)]
    AnNaba = 78,

    [SurahInfo("النازعات", 46)]
    AnNaziyat = 79,

    [SurahInfo("عبس", 42)]
    Abasa = 80,

    [SurahInfo("التكوير", 29)]
    AtTakwir = 81,

    [SurahInfo("الإنفطار", 19)]
    AlInfitar = 82,

    [SurahInfo("المطففين", 36)]
    AlMutaffifin = 83,

    [SurahInfo("الإنشقاق", 25)]
    AlInshiqaq = 84,

    [SurahInfo("البروج", 22)]
    AlBuruj = 85,

    [SurahInfo("الطارق", 17)]
    AtTariq = 86,

    [SurahInfo("الأعلى", 19)]
    AlAla = 87,

    [SurahInfo("الغاشية", 26)]
    AlGhashiya = 88,

    [SurahInfo("الفجر", 30)]
    AlFajr = 89,

    [SurahInfo("البلد", 20)]
    AlBalad = 90,

    [SurahInfo("الشمس", 15)]
    AshShams = 91,

    [SurahInfo("الليل", 21)]
    AlLayl = 92,

    [SurahInfo("الضحى", 11)]
    AdDuha = 93,

    [SurahInfo("الشرح", 8)]
    AshSharh = 94,

    [SurahInfo("التين", 8)]
    AtTin = 95,

    [SurahInfo("العلق", 19)]
    AlAlaq = 96,

    [SurahInfo("القدر", 5)]
    AlQadr = 97,

    [SurahInfo("البينة", 8)]
    AlBayyinah = 98,

    [SurahInfo("الزلزلة", 8)]
    AzZalzalah = 99,

    [SurahInfo("العاديات", 11)]
    AlAdiyat = 100,

    [SurahInfo("القارعة", 11)]
    AlQariah = 101,

    [SurahInfo("التكاثر", 8)]
    AtTakathur = 102,

    [SurahInfo("العصر", 3)]
    AlAsr = 103,

    [SurahInfo("الهمزة", 9)]
    AlHumazah = 104,

    [SurahInfo("الفيل", 5)]
    AlFil = 105,

    [SurahInfo("قريش", 4)]
    Quraysh = 106,

    [SurahInfo("الماعون", 7)]
    AlMaun = 107,

    [SurahInfo("الكوثر", 3)]
    AlKawthar = 108,

    [SurahInfo("الكافرون", 6)]
    AlKafiroon = 109,

    [SurahInfo("النصر", 3)]
    AnNasr = 110,

    [SurahInfo("المسد", 5)]
    AlMasad = 111,

    [SurahInfo("الإخلاص", 4)]
    AlIkhlas = 112,

    [SurahInfo("الفلق", 5)]
    AlFalaq = 113,

    [SurahInfo("الناس", 6)]
    AnNas = 114
}
