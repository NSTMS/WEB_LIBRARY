
# WEB LIBRARY konfiguracja

1. #### XAMPP
    - Jeśli nie posiadasz programu ***XAMPP***, pobierz go z [tej strony](https://www.apachefriends.org/pl/download.html) 
    - uruchom XAMPP'a
    - włącz serwery: ***Apache*** i ***MySql*** przyciskami [ **Start** ]
    - przejdź na stronę [phpmyadmin](http://localhost/phpmyadmin/)
    - utwórz nową bazę danych o dowolnej nazwie
    - zaimportuj plik `library.sql` do utworzonej bazy
2. #### VISUAL STUDIO
    - otwórz projekt w edytorze ***Visual Studio***
    - w zakładce  na górnym pasku wbierz ***Narzędzia*** >
        ***Menadżer Pakietów Nuget*** > ***Konsola menadżera pakietów***
    - w otwartej konsoli wklej następującą komendę:\
        `Update-Package Microsoft.CodeDom.Providers.DotNetCompilerPlatform -r`  


### Projekt jest gotowy do uruchomienia!
