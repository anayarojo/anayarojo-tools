## Anaya Rojo Tools

#### Nuget installation:

```
Install-Package AnayaRojoTools -Version 2.0.0
```

#### Configuración de ejemplo para el uso básico de la configuración:

```xml
<?xml version="1.0" encoding="utf-8" ?>
<configuration>
  <connectionStrings>
    <add name="Connection" connectionString=""/>
  </connectionStrings>
  <appSettings>
    <add key="string" value="string"></add>
    <add key="char" value="c"></add>
    <add key="int" value="1"></add>
    <add key="long" value="123456789"></add>
    <add key="float" value="1.5"></add>
    <add key="double" value="1.5"></add>
    <add key="decimal" value="1.5"></add>
    <add key="date" value="13/12/2017"></add>
    <add key="bool" value="True"></add>
    <add key="enum" value="ENUM_A"></add>
  </appSettings>
</configuration>
```

#### Uso básico de la configuración:

```csharp
using System;
using AnayaRojo.Tools.Configs;

public class Program
{
  public static void Main()
  {
    string lStrValue = Config.GetValue<string>("string");
    char lChrValue = Config.GetValue<char>("char");
    int lIntValue = Config.GetValue<int>("int");
    long lLonValue = Config.GetValue<long>("long");
    float lFltValue = Config.GetValue<float>("float");
    double lFltValue = Config.GetValue<double>("double");
    decimal lDmlValue = Config.GetValue<decimal>("decimal");
    DateTime lDtmValue = Config.GetValue<DateTime>("date");
    bool lBolValue = Config.GetValue<bool>("bool");
    SampleEnum lEnmValue = Config.GetValue<SampleEnum>("enum");
  }
}

public enum SampleEnum
{
    ENUM_A,
    ENUM_B,
    ENUM_C
}
```

#### Configuración del log:

```xml
<?xml version="1.0" encoding="utf-8" ?>
<configuration>
    <configSections>
      <section name="logsConfiguration" type="AnayaRojo.Tools.Configs.Sections.LogsSection, AnayaRojo.Tools" />
    </configSections>
    <logsConfiguration>
      <visibility
        showInfo="true"
        showSuccess="true"
        showTracking="true"
        showProcess="true"
        showWarning="true"
        showError="true"
        showException="true">
      </visibility>
      <log
        format="{date} [{type}] {message}"
        dateFormat="yyyy-MM-dd HH:mm:ss"
        active="true"
        webLog="false"
        fullLog="false"
        multiFiles="false"
        fileName="AppLog"
        relativePath="false"
        path="">
      </log>
  </logsConfiguration>
</configuration>
```

#### Uso básico del log:

```csharp
using System;
using AnayaRojo.Tools.Logs;
using AnayaRojo.Tools.Logs.Enums;

public class Program
{
  public static void Main()
  {
    //Default log
    Log.Write("Log test");

    //Write by type
    Log.Write(LogTypeEnum.SUCCESS, "Success log");
    Log.Write(LogTypeEnum.INFO, "Info log");
    Log.Write(LogTypeEnum.PROCESS, "Process log");
    Log.Write(LogTypeEnum.TRACKING, "Tracking log");
    Log.Write(LogTypeEnum.WARNING, "Warning log");
    Log.Write(LogTypeEnum.ERROR, "Error log");
    Log.Write(LogTypeEnum.EXCEPTION, "Exception log");

    //Write with format
    Log.Write(LogTypeEnum.INFO, "Format of the log {0}", "AnayaRojo");

    //Write exception
    Log.Write(new Exception("Log exception"));
  }
}
```

#### Configuración de la consola de logs:

```xml
<?xml version="1.0" encoding="utf-8" ?>
<configuration>
    <configSections>
      <section name="logsConfiguration" type="AnayaRojo.Tools.Configs.Sections.LogsSection, AnayaRojo.Tools" />
    </configSections>
    <logsConfiguration>
      <visibility
        showInfo="true"
        showSuccess="true"
        showTracking="true"
        showProcess="true"
        showWarning="true"
        showError="true"
        showException="true">
      </visibility>
      <consoleLog
        active="true">
    </consoleLog>
  </logsConfiguration>
</configuration>
```

#### Uso básico de la consola de logs:

```csharp
using System;
using AnayaRojo.Tools.Logs;
using AnayaRojo.Tools.Logs.Enums;

public class Program
{
  public static void Main()
  {
    //Default log
    ConsoleLog.Show("Log test");

    //Show by type
    ConsoleLog.Show(LogTypeEnum.SUCCESS, "Success log");
    ConsoleLog.Show(LogTypeEnum.INFO, "Info log");
    ConsoleLog.Show(LogTypeEnum.PROCESS, "Process log");
    ConsoleLog.Show(LogTypeEnum.TRACKING, "Tracking log");
    ConsoleLog.Show(LogTypeEnum.WARNING, "Warning log");
    ConsoleLog.Show(LogTypeEnum.ERROR, "Error log");
    ConsoleLog.Show(LogTypeEnum.EXCEPTION, "Exception log");

    //Show with format
    ConsoleLog.Show(LogTypeEnum.INFO, "Format of the log {0}", "AnayaRojo");

    //Show exception
    ConsoleLog.Show(new Exception("Log exception"));
  }
}
```

#### Configuración del log de eventos:

```xml
<?xml version="1.0" encoding="utf-8" ?>
<configuration>
    <configSections>
      <section name="logsConfiguration" type="AnayaRojo.Tools.Configs.Sections.LogsSection, AnayaRojo.Tools" />
    </configSections>
    <logsConfiguration>
      <visibility
        showInfo="true"
        showSuccess="true"
        showTracking="true"
        showProcess="true"
        showWarning="true"
        showError="true"
        showException="true">
      </visibility>
      <eventLog
        active="true"
        name="AppLog"
        infoId="10"
        successId="10"
        trackingId="30"
        processId="30"
        warningId="40"
        errorId="50"
        exceptionId="60">
      </eventLog>
  </logsConfiguration>
</configuration>
```

#### Uso básico del log de eventos:

```csharp
using System;
using AnayaRojo.Tools.Logs;
using AnayaRojo.Tools.Logs.Enums;

public class Program
{
  public static void Main()
  {
    //Default log
    EventLog.Save("Log test");

    //Save by type
    EventLog.Save(LogTypeEnum.SUCCESS, "Success log");
    EventLog.Save(LogTypeEnum.INFO, "Info log");
    EventLog.Save(LogTypeEnum.PROCESS, "Process log");
    EventLog.Save(LogTypeEnum.TRACKING, "Tracking log");
    EventLog.Save(LogTypeEnum.WARNING, "Warning log");
    EventLog.Save(LogTypeEnum.ERROR, "Error log");
    EventLog.Save(LogTypeEnum.EXCEPTION, "Exception log");

    //Save with format
    EventLog.Save(LogTypeEnum.INFO, "Format of the log {0}", "AnayaRojo");

    //Save exception
    EventLog.Save(new Exception("Log exception"));
  }
}
```

#### Configuración del log en la base de datos:

```xml
<?xml version="1.0" encoding="utf-8" ?>
<configuration>
    <configSections>
      <section name="logsConfiguration" type="AnayaRojo.Tools.Configs.Sections.LogsSection, AnayaRojo.Tools" />
    </configSections>
    <logsConfiguration>
      <visibility
        showInfo="true"
        showSuccess="true"
        showTracking="true"
        showProcess="true"
        showWarning="true"
        showError="true"
        showException="true">
      </visibility>
      <dataBaseLog
        active="true"
        connectionString="Data Source=SERVER;Initial Catalog=DATABASE;User Id=USER;Password=PASSWORD;"
        table="Logs"
        dateFiled="Date"
        typeField="Type"
        messageField="Message">
      </dataBaseLog>
  </logsConfiguration>
</configuration>
```

#### Uso básico del log en la base de datos:

```csharp
using System;
using AnayaRojo.Tools.Logs;
using AnayaRojo.Tools.Logs.Enums;

public class Program
{
  public static void Main()
  {
    //Default log
    DataBaseLog.Save("Log test");

    //Save by type
    DataBaseLog.Save(LogTypeEnum.SUCCESS, "Success log");
    DataBaseLog.Save(LogTypeEnum.INFO, "Info log");
    DataBaseLog.Save(LogTypeEnum.PROCESS, "Process log");
    DataBaseLog.Save(LogTypeEnum.TRACKING, "Tracking log");
    DataBaseLog.Save(LogTypeEnum.WARNING, "Warning log");
    DataBaseLog.Save(LogTypeEnum.ERROR, "Error log");
    DataBaseLog.Save(LogTypeEnum.EXCEPTION, "Exception log");

    //Save with format
    DataBaseLog.Save(LogTypeEnum.INFO, "Format of the log {0}", "AnayaRojo");

    //Save exception
    DataBaseLog.Save(new Exception("Log exception"));
  }
}
```

#### Configuración del log por correo electrónico:

```xml
<?xml version="1.0" encoding="utf-8" ?>
<configuration>
    <configSections>
      <section name="logsConfiguration" type="AnayaRojo.Tools.Configs.Sections.LogsSection, AnayaRojo.Tools" />
    </configSections>
    <logsConfiguration>
      <visibility
        showInfo="true"
        showSuccess="true"
        showTracking="true"
        showProcess="true"
        showWarning="true"
        showError="true"
        showException="true">
      </visibility>
      <mailLog
        active="true"
        applicationName="AnayaRojoTools"
        authorName=""
        server=""
        port=""
        enableSsl=""
        user=""
        password=""
        fromName=""
        fromMail=""
        toName=""
        toMail="">
      </mailLog>
  </logsConfiguration>
</configuration>
```

#### Uso básico del log por correo electrónico

```csharp
using System;
using AnayaRojo.Tools.Logs;
using AnayaRojo.Tools.Logs.Enums;

public class Program
{
  public static void Main()
  {
    //Default log
    MailLog.Send("Log test");

    //Send by type
    MailLog.Send(LogTypeEnum.SUCCESS, "Success log");
    MailLog.Send(LogTypeEnum.INFO, "Info log");
    MailLog.Send(LogTypeEnum.PROCESS, "Process log");
    MailLog.Send(LogTypeEnum.TRACKING, "Tracking log");
    MailLog.Send(LogTypeEnum.WARNING, "Warning log");
    MailLog.Send(LogTypeEnum.ERROR, "Error log");
    MailLog.Send(LogTypeEnum.EXCEPTION, "Exception log");

    //Send with format
    MailLog.Send(LogTypeEnum.INFO, "Format of the log {0}", "AnayaRojo");

    //Send exception
    MailLog.Send(new Exception("Log exception"));
  }
}
```

#### Configuración completa de la librería:

```xml
<?xml version="1.0" encoding="utf-8" ?>
<configuration>
    <configSections>
      <section name="logsConfiguration" type="AnayaRojo.Tools.Configs.Sections.LogsSection, AnayaRojo.Tools" />
    </configSections>
    <logsConfiguration>
      <visibility
        showInfo="true"
        showSuccess="true"
        showTracking="true"
        showProcess="true"
        showWarning="true"
        showError="true"
        showException="true">
      </visibility>
      <log
        format="{date} [{type}] {message}"
        dateFormat="yyyy-MM-dd HH:mm:ss"
        active="true"
        webLog="false"
        fullLog="false"
        multiFiles="false"
        fileName="AppLog"
        relativePath="false"
        path="">
      </log>
      <consoleLog
        active="true">
      </consoleLog>
      <eventLog
        active="true"
        name="AppLog"
        infoId="10"
        successId="10"
        trackingId="30"
        processId="30"
        warningId="40"
        errorId="50"
        exceptionId="60">
      </eventLog>
      <dataBaseLog
        active="true"
        connectionString=""
        table=""
        dateFiled=""
        typeField=""
        messageField="">
      </dataBaseLog>
      <mailLog
        active="true"
        applicationName=""
        authorName=""
        server=""
        port=""
        enableSsl=""
        user=""
        password=""
        fromName=""
        fromMail=""
        toName=""
        toMail="">
      </mailLog>
  </logsConfiguration>
</configuration>
```

See more

[Nuget package page](https://www.nuget.org/packages/AnayaRojoTools/)