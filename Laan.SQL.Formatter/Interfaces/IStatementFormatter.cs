using System;

namespace Laan.SQL.Formatter
{
    public interface IStatementFormatter
    {
        void Execute();
        bool CanInline { get; }
    }
}