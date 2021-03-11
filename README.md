# ReCapProject - Araç Kiralama Sistemi
![cizimbanner2](https://raw.githubusercontent.com/furkanpasaoglu/githubImages/main/Yaz%C4%B1l%C4%B1m%20Geli%C5%9Ftirici%20Yeti%C5%9Ftirme%20kamp%C4%B1.png) 

## :pushpin:Getting Started
![layers](https://github.com/furkanpasaoglu/githubImages/blob/main/About.png)
<br>
## :books:Layers  
![entities](https://github.com/furkanpasaoglu/githubImages/blob/main/Entities%20Layer.png)
### Entities Layer
Veritabanı nesneleri için oluşturulmuş **Entities Katmanı**'nda **Abstract** ve **Concrete** olmak üzere iki adet klasör bulunmaktadır.Abstract klasörü soyut nesneleri, Concrete klasörü somut nesneleri tutmak için oluşturulmuştur.  
![business](https://github.com/furkanpasaoglu/githubImages/blob/main/Business%20Layer.png)
<br>
###  Business Layer
Sunum katmanından gelen bilgileri gerekli koşullara göre işlemek veya denetlemek için oluşturulan **Business Katmanı**'nda **Abstract**,**Concrete**,**Utilities** ve **ValidationRules** olmak üzere dört adet klasör bulunmaktadır.Abstract klasörü soyut nesneleri, Concrete klasörü somut nesneleri tutmak için oluşturulmuştur.Utilities ve ValidationRules klasörlerinde validation işlemlerinin gerçekleştiği classlar mevcuttur.  
<br>
![dal](https://github.com/furkanpasaoglu/githubImages/blob/main/Data%20Access%20Layer.png)
###  Data Access Layer
Veritabanı CRUD işlemleri gerçekleştirmek için oluşturulan **Data Access Katmanı**'nda **Abstract** ve **Concrete** olmak üzere iki adet klasör bulunmaktadır.Abstract klasörü soyut nesneleri, Concrete klasörü somut nesneleri tutmak için oluşturulmuştur.  
<br>

![core](https://user-images.githubusercontent.com/77868230/107870091-c42f6900-6ea6-11eb-863e-63d30fa2128c.png)
###  Core Layer
Bir framework katmanı olan **Core Katmanı**'nda **DataAccess**, **Entities**, **Utilities** olmak üzere 3 adet klasör bulunmaktadır.DataAccess klasörü DataAccess Katmanı ile ilgili nesneleri, Entities klasörü Entities katmanı ile ilgili nesneleri tutmak için oluşturulmuştur. Core katmanının .Net Core ile hiçbir bağlantısı yoktur.Oluşturulan core katmanında ortak kodlar tutulur. Core katmanı ile, kurumsal bir yapıda, alt yapı ekibi ilgilenir.  
> **⚠ DİKKAT: .**  
> Core Katmanı, diğer katmanları referans almaz.


![database](https://github.com/furkanpasaoglu/githubImages/blob/main/Database%20and%20Tables.png)
###  Veritabanı Oluşturma 
Araba Kiralama Projemiz localdb ile çalışmaktadır. **LocalDb**'de veritabanı oluşturmak için **Visual Studio 2019** için *View > SQL Server Object Explorer* menü yolunu takip edebilirsiniz.Pencere açıldıktan sonra *SQL Server > (localdb)MSSQLLocalDB* altındaki **Databases** klasörüne sağ tıklayıp Add **New Database** seçeneğini ile veritabanınızı oluşturabilirsiniz. Veritabanı oluşturulduktan sonra **New Query** seçerek aşağıda bulunan Sql File ile veritabanınızda olması gereken tabloları oluşturabilirsiniz.  
- [SqlQuery.sql](https://github.com/furkanpasaoglu/ReCapProject/blob/master/SQLQuery.sql) *(Tablonuzu linkde gördüğünüz şekilde oluşturun)*
<br>

![prerequisites](https://raw.githubusercontent.com/furkanpasaoglu/githubImages/main/Prerequisites.png) 
### Nuget
```
Autofac Version="6.1.0"
Autofac.Extensions.DependencyInjection Version="7.1.0"
Autofac.Extras.DynamicProxy Version="6.0.0"
FluentValidation Version="9.5.1"
Microsoft.AspNetCore.Http Version="2.2.2"
Microsoft.AspNetCore.Http.Features Version="5.0.3"
Microsoft.AspNetCore.Http.Abstractions Version="2.2.0"
Microsoft.EntityFrameworkCore.SqlServer Version="3.1.1"
Microsoft.IdentityModel.Tokens Version="6.8.0"
System.IdentityModel.Tokens.Jwt Version="6.8.0"
```


## Araba Kiralama Projesi ile ilgili Notlar
- [SqlQuery.sql](https://github.com/furkanpasaoglu/ReCapProject/blob/master/SQLQuery.sql) *(Tablonuzu linkde gördüğünüz   şekilde oluşturun)*
- *7.Haftadaki DataAccess katmanında bulunan Abstract kısım Generic Repository Design Pattern ile güncellendi.*
- *7.Haftadaki DataAccess katmanında bulunan InMemoryCarDal güncellendi. (LINQ kodları eklenmiştir.)*
- *8.Hafta ödevine ilişkin EntityFramework kodları yazıldı.*
- *9.Hafta ödevine ilişkin Core Katmanı kodları yazıldı.*
- *ConsoleUI' da yapılacan Add, Update, Delete işlemlerini ilgili fonksiyonlardan güncelleyebilirsiniz.*
- *10.Hafta ödevine ilişkin Business Katmanın'da Constant Eklendi ve Messages Kodları Yazıldı.* 
- *10.Hafta ödevine ilişkin Core Katmanın'da Utilities Eklendi ve Result ve DataResult Kodları Yazıldı..* 
- *11.Hafta WebAPI Eklendi ve Kodları Yazıldı.*
- *12.Hafta Autofac ve FluentValidation Kodları Yazıldı.*
- *12.Hafta Artık projede AOP ve IoC yapıları kullanılıyor.*
- *13.Hafta Veritabanına CarImages Tablosu Eklendi.*
- *13.Hafta Projeye Dosya Yükleme (File Helper) Sistemi Yazıldı.*
- *14.Hafta Veritabanı Güncellendi.*
- *14.Hafta JWT Entegrasyonu Yapıldı.*
- *15.Hafta Cache, Transaction ve Performance Entegrasyonu Yapıldı.*

<br>

## :pencil2:Authors
* **Furkan Paşaoğlu** - [furkanpasaoglu](https://github.com/furkanpasaoglu)
