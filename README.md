Detta är en Blazor Web App med interactive server render mode.
Applikationen visar nyheter från Sydsvenskan på olika sätt till användaren. Användaren kan välja mellan olika sätt att visa nyheterna, antingen en i taget eller flera.
Ett RSS flöde används för att hämta nyheterna. Om muspekaren är av skärmen kommer applikationen automatiskt gå igenom nyheterna för användaren, applikationen stannar på en nyhet/nyhetssida i ungefär 15 sekunder innan den går till nästa.



Instruktioner för användning:
- Kräver .NET 8.0
- NuGet packages: Blazor.Bootstrap, System.ServiceModel.Syndication
- När du startar applikationen är den i "Slides" läge som visar en nyhet i taget. För att komma till nästa nyhet kan du klicka höger, för att gå till en föregående nyhet kan du klicka vänster.
- För att starta automatiskt läge i "Slides" behöver musen vara av skärmen.
- För att gå till andra sätt att visa nyheterna rör du muspekaren till hörnet längst upp till vänster och klickar på en av alternativen.
- Läget "Scroll" visar 4 nyheter samtidigt och går automatiskt igenom fler nyheter.
