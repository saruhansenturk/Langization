## Langization Package 🔄️

#### This package simply performs your localization process.
#### You can see below how to use it.
``` csharp
using Langization;

var provider = new JsonLangizationProvider("translations.json");
var manager = new LangizationManager(provider);

manager.SetCulture("tr");

Console.WriteLine(manager.Translate("Hello"));
Console.WriteLine(manager.Translate("WelcomeMessage", "Saruhan"));
```

#### The structure of json should be as seen below.

``` json
{
  "en": {
    "Hello": "Hello",
    "WelcomeMessage": "Welcome, {0}!"
  },
  "tr": {
    "Hello": "Merhaba",
    "WelcomeMessage": "Hoş geldiniz, {0}!"
  }
}
```