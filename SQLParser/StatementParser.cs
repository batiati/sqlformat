using System;

namespace Laan.SQL.Parser
{
    /// <summary>
    /// Base class for parsing an SQL statement
    /// </summary>
    public abstract class StatementParser
    {
        protected const string COMMA = ",";

        public StatementParser( Tokenizer tokenizer )
        {
            Tokenizer = tokenizer;
        }

        protected void ExpectToken( string token )
        {
            if ( CurrentToken.ToLower() != token.ToLower() )
                throw new ExpectedTokenNotFoundException( token, CurrentToken );
            else
                ReadNextToken();
        }

        protected void ExpectTokens( string[] tokens )
        {
            foreach ( string token in tokens )
                ExpectToken( token );
        }

        protected void ReadNextToken()
        {
            Tokenizer.ReadNextToken();
        }

        protected string CurrentToken
        {
            get { return Tokenizer.Current; }
        }

        protected bool IsTokenInSet( string[] tokenSet )
        {
            foreach ( var token in tokenSet )
                if ( token.ToLower() == CurrentToken.ToLower() )
                    return true;

            return false;
        }

        protected Tokenizer Tokenizer { get; private set; }

        /// <summary>
        /// Returns an IStatement reference for the given statement type
        /// </summary>
        /// <returns></returns>
        public abstract IStatement Execute();
    }
}
