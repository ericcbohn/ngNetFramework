NOTE: you need to add your own log4net.config file at the root of ngMayo.Logging

<?xml version="1.0" encoding="utf-8" ?>
<log4net>
  <level>
    <name value="EMAILONLY"/>
    <value value="200000"/>
    <displayName value="EMAILONLY"/>
  </level>
  <appender name="RollingLogFileAppender" type="log4net.Appender.RollingFileAppender">
      <file type="log4net.Util.PatternString" value="App_Data/log/%property{LogName}" />
      <appendToFile value="true" />
      <rollingStyle value="Date" />
      <datePattern value="yyyyMMdd" />
      <layout type="log4net.Layout.PatternLayout">
        <!-- http://logging.apache.org/log4net/release/sdk/?topic=html/T_log4net_Layout_PatternLayout.htm -->
        <conversionPattern value="%utcdate{ABSOLUTE} [%thread] %-5level %logger - %message%newline" />
      </layout>
    </appender>
  <appender name="SmtpAppenderEmailOnly" type="ngMayo.Logging.Appenders.AuthenticatedSmtpAppender">
    <to value="your.email@mayo.edu" />
    <from value="ngMayo&lt;ngMayo@mayo.edu&gt;" />
    <isbodyhtml value="true" />
    <subject value="ngMayo: Email Notification" />
    <smtpHost value="your.smtp.host" />
    <evaluator type="log4net.Core.LevelEvaluator">
      <threshold value="EMAILONLY"/>
    </evaluator>
    <filter type="log4net.Filter.LevelMatchFilter">
      <acceptOnMatch value="true" />
      <levelToMatch  value="EMAILONLY" />
    </filter>
    <filter type="log4net.Filter.DenyAllFilter" />
    <layout type="log4net.Layout.PatternLayout">
      <conversionPattern value="%newline%date [%thread] %-5level %logger - %message%newline%newline%newline" />
    </layout>
  </appender>
  <appender name="Console" type="log4net.Appender.ConsoleAppender">
    <layout type="log4net.Layout.PatternLayout">
      <!-- Print the date in ISO 8601 format -->
      <conversionPattern value="%date [%thread] %-5level %logger - %message%newline" />
    </layout>
  </appender>
  <appender name="ngMayoSplunkAppender" type="Mayo.PopHealth.Common.SplunkAppender.Log4Net.SplunkHttpAppender, Mayo.PopHealth.Common.SplunkAppender.Log4Net">
    <uristring value="https://yoursplunkurl.com" />
    <authorization value="Splunk <your splunk auth id>" />
    <splunkIncludeHost value="True" />
    <splunkSource value="ngMayo" />
    <splunkSourceType value="SplunkAdminDefined" />
    <splunkIndex value="your_index" />
    <maxCloseDelayMilliseconds value="15000" />
    <sendMessageThreadCount value="6" />
    <waitOneMilliseconds value="250" />
    <layout type="log4net.Layout.PatternLayout">
      <conversionPattern value="%date{yyyy-MMM-dd HH:mm:ss.fff} [%thread] LogLevel=%-5level Logger=%logger %message" />
    </layout>
  </appender>
  <appender name="SmtpAppender" type="ngMayo.Logging.Appenders.AuthenticatedSmtpAppender">
    <to value="your.email@mayo.edu" />
    <from value="ngMayo&lt;ngMayo@mayo.edu&gt;" />
    <isbodyhtml value="true" />
    <subject value="ngMayo: Failure Notification" />
    <smtpHost value="your.smtp.host" />
    <evaluator type="log4net.Core.LevelEvaluator">
      <threshold value="FATAL"/>
    </evaluator>
    <filter type="log4net.Filter.LevelMatchFilter">
      <acceptOnMatch value="true" />
      <levelToMatch  value="FATAL" />
    </filter>
    <filter type="log4net.Filter.DenyAllFilter" />
    <layout type="log4net.Layout.PatternLayout">
      <conversionPattern value="%newline%date [%thread] %-5level %logger - %message%newline%newline%newline" />
    </layout>
  </appender>
  <root>
    <appender-ref ref="RollingLogFileAppender" />
    <appender-ref ref="Console" level="DEBUG" />
    <appender-ref ref="SmtpAppender"/>
    <appender-ref ref="SmtpAppenderEmailOnly"/>
    <appender-ref ref="ngMayoSplunkAppender" level="INFO" />
  </root>
</log4net>