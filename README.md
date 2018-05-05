## AnayaRojo Tools

#### Nuget installation:

```
Install-Package AnayaRojoTools -Version 1.0.0
```

#### Log configuration:

```xml
<?xml version="1.0" encoding="utf-8" ?>
<configuration>
  <appSettings>
    <!-- LOG -->
    <add key="ShowConsole" value="false" />
    <add key="SaveEventLog" value="false" />
    <add key="FullLog" value="true" />
    <add key="LogName" value="AplicationLog" />
  </appSettings>
</configuration>
```

#### Log basic use:

```csharp
using System;
using AnayaRojo.Tools.Log;

public class Program
{
	public static void Main()
	{
            ArLog.WriteInfo("Para escribir información");
            ArLog.WriteSuccess("Para escribir proceso exitoso");
            ArLog.WriteTracking("Para escribir seguimiento de proceso");
            ArLog.WriteProcess("Para escribir proceso");
            ArLog.WriteWarning("Para escribir advertencia");
            ArLog.WriteError("Para escribir error");
            ArLog.WriteException("Para escribir excepción");
	}
}
```

#### Configuration example:

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

#### Configuration basic use example:

```csharp
using System;
using AnayaRojo.Tools.Config;

public class Program
{
	public static void Main()
	{
            string lStrValue = ArConfig.GetValue<string>("string");
            char lChrValue = ArConfig.GetValue<char>("char");
            int lIntValue = ArConfig.GetValue<int>("int");
            long lLonValue = ArConfig.GetValue<long>("long");
            float lFltValue = ArConfig.GetValue<float>("float");
            double lFltValue = ArConfig.GetValue<double>("double");
            decimal lDmlValue = ArConfig.GetValue<decimal>("decimal");
            DateTime lDtmValue = ArConfig.GetValue<DateTime>("date");
            bool lBolValue = ArConfig.GetValue<bool>("bool");
            SampleEnum lEnmValue = ArConfig.GetValue<SampleEnum>("enum");
	}
}

public enum SampleEnum
{
    ENUM_A,
    ENUM_B,
    ENUM_C
}
```

See more

[Nuget package page](https://www.nuget.org/packages/AnayaRojoTools/)