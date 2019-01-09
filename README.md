# INSTALL

https://github.com/zuleyhaay/pomodoro/tree/master/PomodoroSetup/Debug/PomodoroSetup.msi?inline=false

**If you have older version of this application you should install again **

After installing the Setup file, install the application from the Install App settings of the Pomodoro app (https://api.slack.com/apps/ADU9GKXKM/install-on-team)
automatically copy your generated OAuth tokens.

You must update the configuration file in the Polisoft folder in the program files on the local disk with the token that you copied.

The configuration file should be:

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

## INFORMATION

This application was made for a company that using slack.
