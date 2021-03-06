﻿using ME3Script.Analysis.Visitors;
using ME3Script.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ME3Script.Language.Tree
{
    public class CompositeSymbolRef : SymbolReference
    {
        public Expression InnerSymbol;
        public Expression OuterSymbol;

        public CompositeSymbolRef(Expression outer, Expression inner, SourcePosition start, SourcePosition end)
            : base(inner, start, end)
        {
            InnerSymbol = inner;
            OuterSymbol = outer;
            Type = ASTNodeType.CompositeReference;
        }

        public override bool AcceptVisitor(IASTVisitor visitor)
        {
            return visitor.VisitNode(this);
        }

        public override VariableType ResolveType()
        {
            return InnerSymbol.ResolveType();
        }
    }
}
