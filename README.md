# ReCapProject - Araç Kiralama Sistemi
Genel olarak proje katmanlı mimariye uygun şekilde tasarlanıp OOP olarak entity framework kullanılmaktadır.IoC prensibi ve SOLID ilkeleri ile geliştirilmeye devam ediyor.AutoFac ve FluentValidation paketleri kullanılıyor .Proje API üzerinden devam ediyor.
# Layers
- [Business](https://github.com/cenkerkumlucali/ReCapProject/tree/master/Business):Sunum katmanından gelen bilgileri gerekli koşullara göre işlemek veya denetlemek için oluşturulan Business Katmanı'nda Abstract,Concrete,Utilities ve ValidationRules olmak üzere dört adet klasör bulunmaktadır.Abstract klasörü soyut nesneleri, Concrete klasörü somut nesneleri tutmak için oluşturulmuştur.Utilities ve ValidationRules klasörlerinde validation işlemlerinin gerçekleştiği classlar mevcuttur.
- [Core](https://github.com/cenkerkumlucali/ReCapProject/tree/master/Core):Bir framework katmanı olan Core Katmanı'nda DataAccess, Entities, Utilities olmak üzere 3 adet klasör bulunmaktadır.DataAccess klasörü DataAccess Katmanı ile ilgili nesneleri, Entities klasörü Entities katmanı ile ilgili nesneleri tutmak için oluşturulmuştur. Core katmanının .Net Core ile hiçbir bağlantısı yoktur.Oluşturulan core katmanında ortak kodlar tutulur. Core katmanı ile, kurumsal bir yapıda, alt yapı ekibi ilgilenir. 
- [DataAccess](https://github.com/cenkerkumlucali/ReCapProject/tree/master/DataAccess):Veritabanı CRUD işlemleri gerçekleştirmek için oluşturulan Data Access Katmanı'nda Abstract ve Concrete olmak üzere iki adet klasör bulunmaktadır.Abstract klasörü soyut nesneleri, Concrete klasörü somut nesneleri tutmak için oluşturulmuştur. 
- [Entites](https://github.com/cenkerkumlucali/ReCapProject/tree/master/Entities):Veritabanı nesneleri için oluşturulmuş Entities Katmanı'nda Abstract ve Concrete olmak üzere iki adet klasör bulunmaktadır.Abstract klasörü soyut nesneleri, Concrete klasörü somut nesneleri tutmak için oluşturulmuştur. 
- [WebAPI](https://github.com/cenkerkumlucali/ReCapProject/tree/master/WebAPI) 
- [ConsoleUI](https://github.com/cenkerkumlucali/ReCapProject/tree/master/ConsoleUI) 

#### Prerequest 

 - [ ] EntityFrameworkCore.SqlServer 3.1.11
 - [ ]  FluentValidation 7.3.3
 - [ ] Autofac 6.1.0
 - [ ] Autofac.Extensions.DependencyInjection 7.1.0
 - [ ] Autofac.Extras.DynamicProxy 6.0.0 
                
----
                    
                
