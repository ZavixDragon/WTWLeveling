using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Config;
using NLog.Extensions.Logging;
using NLog.Targets;
using SumoLogic.Logging.NLog;
using LogLevel = NLog.LogLevel;

namespace Extendhealth.RetailLeads.Service
{
    public class NLogConfiguration
    {
        private readonly Dictionary<string, LogLevel> _logLevels = new Dictionary<string, LogLevel>
        {
            { "trace", LogLevel.Trace },
            { "debug", LogLevel.Debug },
            { "info", LogLevel.Info },
            { "warn", LogLevel.Warn },
            { "error", LogLevel.Error },
            { "fatal", LogLevel.Fatal }
        };
        private readonly ILoggerFactory _loggerFactory;
        private readonly IConfigurationRoot _configuration;

        public NLogConfiguration(ILoggerFactory loggerFactory, IConfigurationRoot configuration)
        {
            _loggerFactory = loggerFactory;
            _configuration = configuration;
        }

        public void Configure()
        {
            _loggerFactory.AddNLog();
            var logLevel = _logLevels[_configuration["LogLevel"].ToLower()];
            var config = new LoggingConfiguration();
            config.AddRule(minLevel: LogLevel.Trace, maxLevel: LogLevel.Error, target: new NullTarget(), loggerNamePattern: "Microsoft.*", final: true);
            config.AddRule(minLevel: logLevel, maxLevel: LogLevel.Fatal, target: CreateFileTarget());
            config.AddRule(minLevel: logLevel, maxLevel: LogLevel.Fatal, target: CreateSumoTarget());
            LogManager.Configuration = config;
        }

        private FileTarget CreateFileTarget()
        {
            var baseLocation = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "retail-leads");
            return new FileTarget
            {
                FileName = Path.Combine(baseLocation, "RetailLeadsLog.log"),
                Layout = "${longdate}  |  ${level:uppercase=true}  |  ${message}",
                KeepFileOpen = true,
                ArchiveFileName = baseLocation + "\\RetailLeadsLog.{#}.log",
                ArchiveNumbering = ArchiveNumberingMode.Date,
                ArchiveDateFormat = "yyyyMMdd",
                MaxArchiveFiles = 10000
            };
        }

        private SumoLogicTarget CreateSumoTarget()
        {
            return new SumoLogicTarget()
            {
                Url = _configuration["SumoUrl"],
                Layout = "${longdate}  |  ${level:uppercase=true}  |  ${machinename}  |  ${message}"
            };
        }
    }
}
