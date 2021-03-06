﻿using ME3Script.Compiling.Errors;
using ME3Script.Lexing.Matching;
using ME3Script.Lexing.Matching.StringMatchers;
using ME3Script.Lexing.Tokenizing;
using ME3Script.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ME3Script.Lexing
{
    public class StringLexer : LexerBase<String>
    {
        private SourcePosition StreamPosition;
        private MessageLog Log;

        public StringLexer(String code, MessageLog log = null, List<KeywordMatcher> delimiters = null, List<KeywordMatcher> keywords = null) 
            : base(new StringTokenizer(code))
        {
            delimiters = delimiters ?? GlobalLists.Delimiters;
            keywords = keywords ?? GlobalLists.Keywords;
            Log = log ?? new MessageLog();

            TokenMatchers = new List<ITokenMatcher<String>>();

            TokenMatchers.Add(new StringLiteralMatcher());
            TokenMatchers.Add(new NameLiteralMatcher());
            TokenMatchers.AddRange(delimiters);
            TokenMatchers.AddRange(keywords);
            TokenMatchers.Add(new WhiteSpaceMatcher());
            TokenMatchers.Add(new NumberMatcher(delimiters));
            TokenMatchers.Add(new WordMatcher(delimiters));

            StreamPosition = new SourcePosition(0, 0, 0);
        }

        public override Token<String> GetNextToken()
        {
            if (Data.AtEnd())
            {
                return new Token<String>(TokenType.EOF);
            }

            Token<String> result =
                (from matcher in TokenMatchers
                 let token = matcher.MatchNext(Data, ref StreamPosition, Log)
                 where token != null
                 select token).FirstOrDefault();

            if (result == null)
            {
                Log.LogError("Could not lex '" + Data.CurrentItem + "'",
                    StreamPosition, StreamPosition.GetModifiedPosition(0, 1, 1));
                Data.Advance();
                return new Token<String>(TokenType.INVALID);
            }
            return result;
        }

        public override IEnumerable<Token<string>> LexData()
        {
            StreamPosition = new SourcePosition(0, 0, 0);
            var token = GetNextToken();
            while (token.Type != TokenType.EOF)
            {
                if (token.Type != TokenType.WhiteSpace)
                    yield return token;

                token = GetNextToken();
            }
        }

        public IEnumerable<Token<string>> LexSubData(SourcePosition start, SourcePosition end)
        {
            StreamPosition = start;
            Data.Advance(start.CharIndex);
            var token = GetNextToken();
            // TODO: this assumes well-formed subdata, fix?
            while (!token.StartPosition.Equals(end))
            {
                if (token.Type != TokenType.WhiteSpace)
                    yield return token;

                token = GetNextToken();
            }
        }
    }
}
