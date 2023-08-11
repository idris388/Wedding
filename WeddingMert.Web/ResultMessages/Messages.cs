namespace WeddingMert.Web.ResultMessages
{
   public static class Messages
    {
        public static class Contact
        {
            public static string Add(string contactName)
            {
                return $"{contactName} isimli başarıyla gönderilmiştir.";
            }
            public static string Update(string contactName)
            {
                return $"{contactName} başlıklı makale başarıyla güncellenmiştir.";
            }
            public static string Delete(string contactName)
            {
                return $"{contactName} başlıklı makale başarıyla silinmiştir.";
            }
            public static string UndoDelete(string contactName)
            {
                return $"{contactName} başlıklı makale başarıyla geri alınmıştır.";
            }
        }
        public static class About
        {
            public static string Update(string aboutTitle)
            {
                return $"{aboutTitle} Başlıklı hakkımızda güncellenmiştir.";
            }
        }
        public static class Gallery
        {
            public static string Add(string aboutTitle)
            {
                return $"{aboutTitle} Başlıklı görsel eklenmiştir.";
            }
        }
    }
}
