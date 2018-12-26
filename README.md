# Yükleme

http://10.0.0.73/zuleyhaay/pomodoro/raw/master/PomodoroSetup/Debug/PomodoroSetup.msi?inline=false

**Eğer bilgisayarınızda uygulamanın daha eski bir sürümü yüklüyse eski sürümünü kaldırmalısınız**

Setup dosyasını yükledikten sonra Pomodoro uygulamasının Install App ayarlarından uygulamayı kurup (https://api.slack.com/apps/ADU9GKXKM/install-on-team)
otomatik olarak oluşturulan OAuth token'larınızı kopyalamalısınız.

Kopyaladığınız token'larınızla yerel diskteki program dosyalarında Polisoft klasörünün içindeki yapılandırma dosyasını güncellemelisiniz. 

Yapılandırma dosyası şu şekilde olmalı:

```xml
<?xml version="1.0" encoding="utf-8"?>

<configuration>

  <startup>
    <supportedRuntime version="v4.0" sku=".NETFramework,Version=v4.6.1" />
  </startup>
  <appSettings>
    <add key="token" value="xoxp-???-???-???" />
  </appSettings>
  
</configuration>
```