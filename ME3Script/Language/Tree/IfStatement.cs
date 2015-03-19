﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ME3Script.Language.Tree
{
    public class IfStatement : Statement
    {
        public Expression Condition;
        public Statement Then;
        public Statement Else;

        public IfStatement() : base(ASTNodeType.IfStatement) { }
    }
}
