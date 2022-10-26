using System;
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
        public Result(string textLog, TypeLog typeLog, bool status)
        {
            _textLog = textLog;

            _typeLog = typeLog;

            _status = status;
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

        // public bool Status
        // {
        //    get { return _status; }
        //    set { _status = value; }
        // }
    }
}
