using NLog;
using System;
using System.Runtime.ExceptionServices;

namespace CasterCore
{
    public static class CasterLogger
    {
        private static readonly Logger _logger = LogManager.GetCurrentClassLogger();

        static CasterLogger()
        {
            AppDomain.CurrentDomain.FirstChanceException += FirstChanceException;
            AppDomain.CurrentDomain.UnhandledException += UnhandledException;  // this method probably won't be called because the simulator will catch all errors
        }

        private static void FirstChanceException(object sender, FirstChanceExceptionEventArgs e)
        {
            Error($"FirstChanceException: {e.Exception.Message}");
            Error(e.Exception.StackTrace);
        }

        private static void UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Error(e.ExceptionObject.ToString());
        }

        public static void Shutdown()
        {
            LogManager.Shutdown();
        }

        public static void Debug(string msg)
        {
            //var file = LogManager.GetRepository().GetAppenders().FirstOrDefault() as FileAppender;
            //MessageBox.Show(file.File, "test");
            _logger.Debug(msg);
        }

        public static void DebugFormatted(string format, params object[] args)
        {
            _logger.Debug(format, args);
        }

        public static void Info(object message)
        {
            _logger.Info(message);
        }

        public static void InfoFormatted(string format, params object[] args)
        {
            _logger.Info(format, args);
        }

        public static void Warn(object message)
        {
            _logger.Warn(message);
        }

        public static void Warn(string message, Exception exception)
        {
            _logger.Warn(exception,message);
        }

        public static void WarnFormatted(string format, params object[] args)
        {
            _logger.Warn(format, args);
        }

        public static void Error(object message)
        {
            _logger.Error(message);
        }

        public static void Error(string message, Exception exception)
        {
            _logger.Error(exception, message);
        }

        public static void ErrorFormatted(string format, params object[] args)
        {
            _logger.Error(format, args);
        }

        public static void Fatal(object message)
        {
            _logger.Fatal(message);
        }

        public static void Fatal(string message, Exception exception)
        {
            _logger.Fatal(exception,message);
        }

        public static void FatalFormatted(string format, params object[] args)
        {
            _logger.Fatal(format, args);
        }

    }
}
