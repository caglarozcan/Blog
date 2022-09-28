# Blog Projesi

ASP.Net MVC Core 6 üzerinde DDD (Domain Driven Design) ile geliştirilen blog projesi

## Proje Katmanları
Proje katmanları aşağıdaki gibidir.
* Core
    - Blog.Application
    - Blog.Domain
* Infrastructure
    - Blog.Infrastructure
    - Blog.Persistence
* Presentation
    - Blog.Script
    - Blog.Web

### Core Katmanı
#### Blog.Application
Somut sınıflar ile ilgili arayüzler (interface), DTO (Data Transfer Object), sabitler (enums), genel response ve request modellerini barındırır.

#### Blog.Domain
Entity Framework yapılandırması için gerekli olan Entity sınıflarını barındırır.

### Infrastructure Katmanı
#### Blog.Infrastructure
Uygulamanın iş mantığı (Business Logic) kısmını oluşturan servis sınıflarının somut hallerinin tutulduğu katmandır.

#### Blog.Persistence
Entity Framework için gerekli olan DbContext ve Entity konfigürasyonlarının bulunduğu katmandır. Repository ve Unit Of Work tasarım deseni için gerekli somut sınıflar bulunur.

### Presentation Katmanı
#### Blog.Script
Kullanıcı arayüzü bileşenleri Vanilla JS ile modül olarak geliştirilir ve NodeJS üzerinde webpack ile paket haline getirilerek View'lar üzerinde kullanılır.

#### Blog.Web
ASP.Net MVC projesinin bulunduğu katmandır. Kullanıcı arayüzleri bu proje altında geliştirilir. Admin paneli proje içerisinde Area/Admin kısmında bulunmaktadır.
