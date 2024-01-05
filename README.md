[![Review Assignment Due Date](https://classroom.github.com/assets/deadline-readme-button-24ddc0f5d75046c5622901739e7c5dd533143b0c8e959d652212380cedb1ea36.svg)](https://classroom.github.com/a/GfoSvSyx)

# Akbank .Net Bootcamp Ödevi
Akbank ve patikadev tarafından gerçekleştirilen Asp.Net eğitimi sürecinde verilen Üçüncü ödevde, canlı dersimiz esnasında oluşturulan modeller'ın Controller'ları için Command ve Queryler  GET, GETbyId, GETbyParemeter, PUT, POST, DELETE method'ları 3 command 3 query olarak hazırlanması istendi.

[Akbank .Net Bootcamp Ödev 1](https://github.com/300-Akbank-Net-Bootcamp/aw-1-ysfArslan1)

[Akbank .Net Bootcamp Ödev 2](https://github.com/300-Akbank-Net-Bootcamp/aw-2-ysfArslan1)

![Resim Açıklaması](images/va.jpeg)

## Command ve Querylerin oluşturulması :
Bizden istenilen metotların oluşturulması için her model için içerisinde GET, GETbyId, GETbyParemeter metotlarının oldugu Query dosyası ve PUT, POST, DELETE metotlarının oldugu Command dosyası oluşturdum.


![Resim Açıklaması](images/m.jpeg)


## Validationlar :
Projede kullanıcıdan gelen bütün modellerin requestlerin dogrulanması için validasyon dosyaları oluşturdum. 

![Resim Açıklaması](images/v.jpeg)

## Database komutları :
- Projede veri tabanı olarak Microsoft SQL Server kullanıldı. Migration eklemek için kullanılan komut:
    ```
        dotnet ef migrations add mig1 --project Vb.Data --startup-project Vb.Api
    ```
-  Eklenen Migration'ların uygulanması için kullanılan komut ise şu şekildedir:
    ```
           dotnet ef database update --project "./Vb.Data" --startup-project "./Vb.Api"
    ```
