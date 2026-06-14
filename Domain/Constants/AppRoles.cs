namespace Domain.Constants
{
    /// <summary>
    /// الأدوار الثابتة في النظام
    /// ─────────────────────────────────────────────────────────
    /// Admin        : مدير التطبيق — صلاحيات كاملة
    /// Support      : فريق الدعم الفني — يشوف الشكاوى والمحادثات فقط
    /// ImportOffice : مكتب/شركة استيراد مسجَّلة — يدير الشحنات والتخليص والكونتنرات
    /// Exporter     : صاحب منتج قابل للتصدير — يعرض منتجاته ويتواصل مع المشترين
    /// Customer     : مستخدم عادي — يطلب استيراد ويتابع شحناته
    /// ─────────────────────────────────────────────────────────
    /// ملاحظة: Admin و Support لا يُنشَآن من API — يُنشَآن من Seed فقط.
    /// </summary>
    public static class AppRoles
    {
        public const string Admin = "Admin";
        public const string Trader = "Trader";
        public const string Customer = "Customer";

        public static readonly string[] All = { Admin, Trader, Customer };

 
        public static readonly string[] AllowedForRegistration = { Customer, Trader };
    }
}