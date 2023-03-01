
# WEB LIBRARY konfiguracja

1. #### XAMPP
    - Jeśli nie posiadasz programu ***XAMPP***, pobierz go ze strony [apachefriends.org](https://www.apachefriends.org/pl/download.html) 
    - uruchom XAMPP'a
    - włącz serwery: ***Apache*** i ***MySql*** przyciskami [ **Start** ]
    - przejdź na stronę [phpmyadmin](http://localhost/phpmyadmin/)
    - utwórz nową bazę danych o dowolnej nazwie
    - zaimportuj plik `library.sql` do utworzonej bazy
    - domyślnie jest możliwość zalogowania się przy użyciu loginu: ***test*** oraz hasła: ***test***
2. #### VISUAL STUDIO
    - otwórz projekt w edytorze ***Visual Studio***
    - w zakładce  na górnym pasku wbierz ***Narzędzia*** >
        ***Menadżer Pakietów Nuget*** > ***Konsola menadżera pakietów***
    - w otwartej konsoli wklej następującą komendę:\
        `Update-Package Microsoft.CodeDom.Providers.DotNetCompilerPlatform -r`  


### Projekt jest gotowy do uruchomienia!
Po odpaleniu projektu przejdź do strony `/connection.aspx` i zacznij korzystać aplikacji!


**UWAGA!**
By umożliwić wykonanie weryfikacji dwuetapowej w kodzie pliku `userCreateAccountPage.aspx.cs` w metodzie `SendVerificationCodeByEmail` ustaw zmienne `senderEmail`na e-mail, z którego będziemy wysyłać kod weryfikacyjny oraz `senderPassword` na ciąg znaków wygenerowany na stronie [myaccount.google.com/apppasswords](https://myaccount.google.com/apppasswords)
