using System;
using System.Collections.Generic;
using System.Text;
using Entities.DTOs;

namespace Business.Constants
{
    public class Messages
    {
        public static string CarAdded = "Araba eklendi";
        public static string DailyPriceInvalid = "Arabanın günlük fiyatı 0 olamaz";
        public static string CarNameInvalid = "Araba ismi geçersiz";
        public static string MaintenanceTime="Bakımda.";
        public static string CategoryAdded = "Kategori eklendi";
        public static string ColorAdded="Renk eklendi";
        public static string RentalAddedError="Araba şuan mevcut değil";
        public static string CarDeleted="Araba silindi";
        public static string CarUpdate="Araba güncellendi";
        public static string BrandAdded="Marka Eklendi";
        public static string BrandNameInvalid="Marka ismi en az 2 karakterden oluşmalıdır";
        public static string BrandUpdated="Marka güncellendi";
        public static string BrandDeleted="Marka silindi";
        public static string ColorDeleted="Renk silindi";
        public static string ColorUpdated="Renk güncellendi";
        public static string ColorNameInvalid="Renk ismi en az 2 karakterden oluşmalıdır";
        public static string UserAdded="Kullanıcı eklendi";
        public static string UserDeleted="Kullanıcı silindi";
        public static string UserUpdated="Kullanıcı güncellendi";
        public static string CustomerAdded="Müşteri eklendi";
        public static string CustomerDeleted="Müşteri silindi";
        public static string CustomerUpdated="Müşteri güncellendi";
        public static string CategoryDeleted="Kategori silindi";
        public static string CategoryUpdated="Kategori güncellendi";
        public static string RentalDeleted="Kiralama silindi";
        public static string RentalUpdated="Kiralama güncellendi";
        public static string PictureInvalid="Bir arabaya en fazla 5 tane resim eklenebilir.";
        public static string EditCarImageMessage= "Araç resmi başarıyla güncellendi";
        public static string AddCarImageMessage="Araç resmi başarıyla eklendi";
        public static string DeleteCarImageMessage="Araç resmi başarıyla silindi";
        public static string ImagesAdded="Resim eklendi.";
        public static string FailAddedImageLimit = "Resim limitine erişildi!";
        public static string CarImageLimitExceeded;
    }
}
