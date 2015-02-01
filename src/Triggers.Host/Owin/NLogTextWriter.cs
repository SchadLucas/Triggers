﻿namespace Triggers.Host.Owin
{
    using System.IO;
    using System.Text;
    using NLog;

    public class NlogTextWriter : TextWriter
    {
        public NlogTextWriter(Logger logger)
        {
            _logger = logger;
        }

        private readonly Logger _logger;

        public override Encoding Encoding
        {
            get { return Encoding.Default; }
        }

        public override void Write(char[] buffer, int index, int count)
        {
            Write(buffer);
        }

        public override void Write(char[] buffer)
        {
            Write(new string(buffer));
        }

        public override void Write(string value)
        {
            if (value.ToLower().Contains("error") && !(value.ToLower().Contains("sqlite") || value.ToLower().Contains("\"errors\":null"))) {
                _logger.Error(value);
            }
            else {
                _logger.Trace(value);
            }
        }

        public override void Write(char value)
        {
            _logger.Trace(value);
        }
    }
}