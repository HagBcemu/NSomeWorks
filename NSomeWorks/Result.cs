using System;
using System.Collections.Generic;
using System.Text;

namespace NSomeWorks
{
    enum TypeLog
    {
        Error,
        Info,
        Warning
    }

    class Result
    {
        private bool _status;

        private TypeLog _typeLog;

        private string _textLog;

        private DateTime _dateTime;

        public Result(string textLog, TypeLog typeLog, bool status, DateTime dateTime)
        {
            _textLog = textLog;

            _typeLog = typeLog;

            _status = status;

            _dateTime = dateTime;
        }

        public bool Status
        {
            get { return _status; }
        }

        public TypeLog TypeLog
        {
            get { return _typeLog; }
        }

        public string TextLog
        {
            get { return _textLog; }
        }

        public DateTime DateTime
        {
            get { return _dateTime; }
        }
    }
}
