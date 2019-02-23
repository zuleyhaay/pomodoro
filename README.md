# DESCRIPTION

This application's a timer. It's using the pomodoro technique. So what's the point this app? When you're working in a pomodoro time your situation change to red in SLACK. It shows that you're not available except urgent things. In work slot no one disturb you or no longer you get notifications from anyone. When you're in break time your situation change to green. It shows that now you're available for any question or chat. This application intend to increase productivity. And sometimes you can see notifications from app like "Welcome" or "You did four pomodoros today. Good job!".

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
